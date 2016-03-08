﻿// Original Work Copyright (c) Ethan Moffat 2014-2016
// This file is subject to the GPL v2 License
// For additional details, see the LICENSE file

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace EndlessClient.Rendering.Sprites
{
	public class SpriteSheet : ISpriteSheet
	{
		public Texture2D SheetTexture { get; private set; }

		public Rectangle SourceRectangle { get; private set; }

		public SpriteSheet(Texture2D texture)
		{
			SheetTexture = texture;
			SourceRectangle = new Rectangle(0, 0, texture.Width, texture.Height);
		}

		public SpriteSheet(Texture2D texture, Rectangle sourceArea)
		{
			SheetTexture = texture;
			SourceRectangle = sourceArea;
		}

		/// <summary>
		/// Get a new texture containing the data from SheetTexture within the bounds of SourceRectangle. Must be disposed.
		/// </summary>
		/// <returns>New texture containing just the image specified by the SourceRectangle property.</returns>
		public Texture2D GetSourceTexture()
		{
			var colorData = new Color[SourceRectangle.Width*SourceRectangle.Height];
			SheetTexture.GetData(0, SourceRectangle, colorData, 0, colorData.Length);

			var retText = new Texture2D(SheetTexture.GraphicsDevice, SourceRectangle.Width, SourceRectangle.Height);
			retText.SetData(colorData);

			return retText;
		}
	}
}