using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

using EOLib;
using EOLib.Data;
using XNAControls;

namespace EndlessClient
{
	/// <summary>
	/// Game states
	/// </summary>
	public enum GameStates
	{
		/// <summary>
		/// Initial State when game is launched
		/// </summary>
		Initial,
		/// <summary>
		/// State when an account is being created
		/// </summary>
		CreateAccount,
		/// <summary>
		/// State when Login button is clicked, but account is not yet authenticated
		/// </summary>
		Login,
		/// <summary>
		/// Account is authenticated. Show available characters for account
		/// </summary>
		LoggedIn,
		/// <summary>
		/// Roll credits...
		/// </summary>
		ViewCredits,
		/// <summary>
		/// In game
		/// </summary>
		PlayingTheGame
	}

	public partial class EOGame : Game
	{
		const int WIDTH = 640;
		const int HEIGHT = 480;

		Random gen = new Random();
		int currentPersonOne, currentPersonTwo;
		GameStates currentState;

		//Textures actually being drawn by this class (not as components)
		//Components moved to GameUI.cs (partial class)
		Texture2D[] PeopleSetOne;
		Texture2D[] PeopleSetTwo;
		Texture2D UIBackground;
		Texture2D CharacterDisp, AccountCreateSheet, LoginUIScreen;

		//--------------------------
		//***** HELPER METHODS *****
		//--------------------------
		private void TryConnectToServer(Action successAction)
		{
			if (World.Instance.Client.Connected)
			{
				successAction();
				return;
			}

			new System.Threading.Thread(() =>
			{				
				try
				{
					if (!World.Instance.Client.ConnectToServer(Constants.Host, Constants.Port))
					{
						string caption, msg = Handlers.Init.ResponseMessage(out caption);
						EODialog err = new EODialog(this, msg, caption);
						return;
					}
					successAction();
				}
				catch
				{
					EODialog dlg = new EODialog(this, "The game server could not be found. Please try again at a later time", "Could not find server");
				}
			}).Start();
		}

		private void LostConnectionDialog()
		{
			//Eventually these message strings should be loaded from the global constant class, or from dat files somehow. for now this method will do.
			EODialog errDlg = new EODialog(this, "The connection to the game server was lost, please try again at a later time.", "Lost connection");
			if (World.Instance.Client.Connected)
				World.Instance.Client.Disconnect();
			doStateChange(GameStates.Initial);
		}

		private void doShowCharacters()
		{
			//remove any existing character renderers
			List<EOCharacterRenderer> toRemove = new List<EOCharacterRenderer>();
			foreach(IGameComponent comp in Components)
			{
				if (comp is EOCharacterRenderer)
					toRemove.Add(comp as EOCharacterRenderer);
			}
			foreach (EOCharacterRenderer eor in toRemove)
				eor.Close();

			//show the new data
			EOCharacterRenderer[] render = new EOCharacterRenderer[World.Instance.MainPlayer.CharData.Length];
			for (int i = 0; i < World.Instance.MainPlayer.CharData.Length; ++i)
			{
				//need to get actual draw location
				render[i] = new EOCharacterRenderer(this, new Vector2(395, 60 + i * 124), World.Instance.MainPlayer.CharData[i], true);
			}
		}
		
		private void doStateChange(GameStates newState)
		{
			currentState = newState;
			
			List<EOCharacterRenderer> toRemove = new List<EOCharacterRenderer>();
			foreach (DrawableGameComponent component in Components)
			{
				//don't hide dialogs
				if (XNAControl.Dialogs.Contains(component as XNAControl) ||
					XNAControl.Dialogs.Contains((component as XNAControl).TopParent))
					continue;

				if (component is EOCharacterRenderer)
					toRemove.Add(component as EOCharacterRenderer); //this needs to be done separately because it's a foreach loop

				if (component is XNATextBox)
					(component as XNATextBox).Text = "";
				
				component.Visible = false;
			}
			foreach (EOCharacterRenderer eor in toRemove)
			{
				eor.Close();
				eor.Dispose();
			}
			toRemove.Clear();

			switch (currentState)
			{
				case GameStates.Initial:
					ResetPeopleIndices();
					foreach (XNAButton btn in mainButtons)
						btn.Visible = true;
					lblVersionInfo.Visible = true;
					break;
				case GameStates.CreateAccount:
					foreach (XNATextBox txt in accountCreateTextBoxes)
						txt.Visible = true;
					foreach (XNAButton btn in createButtons)
						btn.Visible = true;
					createButtons[0].DrawLocation = new Vector2(359, 417);
					backButton.Visible = true;
					dispatch.Subscriber = accountCreateTextBoxes[0];
					break;
				case GameStates.Login:
					loginUsernameTextbox.Visible = true;
					loginPasswordTextbox.Visible = true;
					foreach (XNAButton btn in loginButtons)
						btn.Visible = true;
					foreach (XNAButton btn in mainButtons)
						btn.Visible = true;
					dispatch.Subscriber = loginUsernameTextbox;
					break;
				case GameStates.ViewCredits:
					foreach (XNAButton btn in mainButtons)
						btn.Visible = true;
					lblCredits.Visible = true;
					break;
				case GameStates.LoggedIn:
					backButton.Visible = true;
					createButtons[0].Visible = true;
					createButtons[0].DrawLocation = new Vector2(334, 417);

					foreach (XNAButton x in loginCharButtons)
						x.Visible = true;
					foreach (XNAButton x in deleteCharButtons)
						x.Visible = true;

					passwordChangeBtn.Visible = true;

					doShowCharacters();
					break;
				case GameStates.PlayingTheGame:
					hud.Visible = true;
					break;
			}
		}

		private void ResetPeopleIndices()
		{
			currentPersonOne = gen.Next(4);
			currentPersonTwo = gen.Next(8);
		}

		//-----------------------------
		//***** DEFAULT XNA STUFF *****
		//-----------------------------

		public EOGame()
		{
			graphics = new GraphicsDeviceManager(this);
			graphics.PreferredBackBufferWidth = WIDTH;
			graphics.PreferredBackBufferHeight = HEIGHT;
			Content.RootDirectory = "Content";
		}

		protected override void Initialize()
		{
			IsMouseVisible = true;
			dispatch = new KeyboardDispatcher(this.Window);
			ResetPeopleIndices();
			
			try
			{
				GFXLoader.Initialize(GraphicsDevice);
				World w = World.Instance; //set up the world
			}
			catch (WorldLoadException wle) //could be thrown from World's constructor
			{
				System.Windows.Forms.MessageBox.Show(wle.Message, "Error");
				Exit();
				return;
			}
			catch (Exception ex) //could be thrown from GFXLoader.Initialize
			{
				System.Windows.Forms.MessageBox.Show("Error initializing GFXLoader: " + ex.Message, "Error");
				Exit();
				return;
			}

			if(World.Instance.EIF != null && World.Instance.EIF.Version == 0)
			{
				System.Windows.Forms.MessageBox.Show("The item pub file you are using is using an older format of the EIF specification. Some features may not work properly. Run the file through a batch processor or use updated pub files.", "Warning");
			}

			GFXTypes curValue = (GFXTypes)0;
			try
			{
				Array values = Enum.GetValues(typeof(GFXTypes));
				foreach (GFXTypes value in values)
				{
					curValue = value;
					using (Texture2D throwAway = GFXLoader.TextureFromResource(value, -99, false)) { }
				}
			}
			catch
			{
				System.Windows.Forms.MessageBox.Show(string.Format("There was an error loading GFX{0:000}.EGF : {1}. Place all .GFX files in .\\gfx\\", (int)curValue, curValue.ToString()), "Error");
				Exit();
				return;
			}
			
			base.Initialize();
		}

		protected override void LoadContent()
		{
			//the content (pun intended) of this method is organized by the control being instantiated
			//maybe split it off into separate "helper" functions for organization? :-/

			spriteBatch = new SpriteBatch(GraphicsDevice);

			//texture for UI background image
			Random gen = new Random();
			UIBackground = GFXLoader.TextureFromResource(GFXTypes.PreLoginUI, 30 + gen.Next(7), false);

			PeopleSetOne = new Texture2D[4];
			PeopleSetTwo = new Texture2D[8];
			//the large character drawings
			for (int i = 1; i <= 4; ++i)
			{
				PeopleSetOne[i - 1] = GFXLoader.TextureFromResource(GFXTypes.PreLoginUI, 40 + i, true);
				//8 graphics in the second set of people: 61-68
				PeopleSetTwo[i - 1] = GFXLoader.TextureFromResource(GFXTypes.PreLoginUI, 60 + i, true);
				PeopleSetTwo[i + 3] = GFXLoader.TextureFromResource(GFXTypes.PreLoginUI, 64 + i, true);
			}
			
			//the username/password prompt background
			LoginUIScreen = GFXLoader.TextureFromResource(GFXTypes.PreLoginUI, 2, false);
			//the character display background w/o login+delete buttons
			CharacterDisp = GFXLoader.TextureFromResource(GFXTypes.PreLoginUI, 11, false);
			//the account create sheet w/labels for text fields
			AccountCreateSheet = GFXLoader.TextureFromResource(GFXTypes.PreLoginUI, 12, true);

			InitializeControls();
		}

		protected override void Update(GameTime gameTime)
		{
			// Allows the game to exit
			if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
				this.Exit();
			
			base.Update(gameTime);
		}

		protected override void Draw(GameTime gameTime)
		{
			GraphicsDevice.Clear(Color.Black);
			spriteBatch.Begin();

			spriteBatch.Draw(UIBackground, new Rectangle(0, 0, WIDTH, HEIGHT), null, Color.White);

			Rectangle personOneRect = new Rectangle(229, 70, PeopleSetOne[currentPersonOne].Width, PeopleSetOne[currentPersonOne].Height);
			Rectangle personTwoRect = new Rectangle(43, 140, PeopleSetTwo[currentPersonTwo].Width, PeopleSetTwo[currentPersonTwo].Height);
			switch (currentState)
			{
				case GameStates.Login:
					spriteBatch.Draw(PeopleSetOne[currentPersonOne], personOneRect, Color.White);
					spriteBatch.Draw(LoginUIScreen, new Vector2(266, 291), Color.White);
					break;
				case GameStates.Initial:
					spriteBatch.Draw(PeopleSetOne[currentPersonOne], personOneRect, Color.White);
					break;
				case GameStates.CreateAccount:
					spriteBatch.Draw(PeopleSetTwo[currentPersonTwo], personTwoRect, Color.White);
					//there are six labels
					for (int srcYIndex = 0; srcYIndex < 6; ++srcYIndex)
					{
						Vector2 lblpos = new Vector2(358, (srcYIndex < 3 ? 50 : 241) + (srcYIndex < 3 ? srcYIndex * 51 : (srcYIndex - 3) * 51));
						spriteBatch.Draw(AccountCreateSheet, lblpos, new Rectangle(0, srcYIndex * (srcYIndex < 2 ? 14 : 15), 149, 15), Color.White);
					}
					break;
				case GameStates.ViewCredits:
					lblCredits.Visible = true;
					break;
				case GameStates.LoggedIn:
					//334, 36
					//334 160
					spriteBatch.Draw(PeopleSetTwo[currentPersonTwo], personTwoRect, Color.White);
					for (int i = 0; i < 3; ++i)
						spriteBatch.Draw(CharacterDisp, new Vector2(334, 36 + i * 124), Color.White);
					break;
			}

			spriteBatch.End();
			base.Draw(gameTime);
		}

		//-------------------
		//***** CLEANUP *****
		//-------------------

		protected override void Dispose(bool disposing)
		{
			if (!World.Initialized)
				return;

			if (World.Instance.Client.Connected)
				World.Instance.Client.Disconnect();
			World.Instance.Client.Dispose();

			loginUsernameTextbox.Dispose();
			loginPasswordTextbox.Dispose();

			foreach (XNAButton btn in mainButtons)
				btn.Dispose();
			foreach (XNAButton btn in loginButtons)
				btn.Dispose();
			foreach (XNAButton btn in createButtons)
				btn.Dispose();

			foreach (XNAButton btn in loginCharButtons)
				btn.Dispose();

			passwordChangeBtn.Dispose();

			backButton.Dispose();

			lblCredits.Dispose();

			foreach (XNATextBox btn in accountCreateTextBoxes)
				btn.Dispose();

			base.Dispose(disposing);
		}
	}
}