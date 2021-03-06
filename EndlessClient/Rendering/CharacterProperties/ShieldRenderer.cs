﻿// Original Work Copyright (c) Ethan Moffat 2014-2016
// This file is subject to the GPL v2 License
// For additional details, see the LICENSE file

using EOLib;
using EOLib.Domain.Character;
using EOLib.Domain.Extensions;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace EndlessClient.Rendering.CharacterProperties
{
    public class ShieldRenderer : ICharacterPropertyRenderer
    {
        private readonly ICharacterRenderProperties _renderProperties;
        private readonly Texture2D _shieldTexture;

        public bool CanRender => _shieldTexture != null && _renderProperties.ShieldGraphic != 0;

        public ShieldRenderer(ICharacterRenderProperties renderProperties,
                              Texture2D shieldTexture)
        {
            _renderProperties = renderProperties;
            _shieldTexture = shieldTexture;
        }

        public void Render(SpriteBatch spriteBatch, Rectangle parentCharacterDrawArea)
        {
            var offsets = GetOffsets();
            var drawLoc = new Vector2(parentCharacterDrawArea.X + offsets.X, parentCharacterDrawArea.Y + offsets.Y);

            spriteBatch.Draw(_shieldTexture, drawLoc, null, Color.White, 0.0f, Vector2.Zero, 1.0f,
                             _renderProperties.IsFacing(EODirection.Up, EODirection.Right) ? SpriteEffects.FlipHorizontally : SpriteEffects.None,
                             0.0f);
        }

        private Vector2 GetOffsets()
        {
            //todo: offsets for shields
            const int bootsOffX = -10, bootsOffY = -7;
            return new Vector2(bootsOffX, bootsOffY);
        }
    }
}
