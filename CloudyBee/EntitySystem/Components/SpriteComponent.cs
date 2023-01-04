using CloudyBeeEngine.Attributes;
using CloudyBeeEngine.Cache;
using CloudyBeeEngine.Template.Components;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace CloudyBeeEngine.EntitySystem.Components
{
    public class SpriteComponent : Component
    {
        private float originalRotation;

        public SpriteComponent(SpriteComponentTemplate spriteComponentTemplate) : base()
        {
            Name = spriteComponentTemplate.Name;
            Texture = TextureCache.GetItem(spriteComponentTemplate.Texture);
            OffSet = spriteComponentTemplate.Offset;
            Rotation = spriteComponentTemplate.Rotation;
            Origin = spriteComponentTemplate.Origin;
            Scale = spriteComponentTemplate.Scale;
            Color = spriteComponentTemplate.Color;
            LockRotation = spriteComponentTemplate.LockRotation;
        }

        #region Public Properties

        public Texture2D Texture { get; set; }

        public Vector2 Origin { get; set; }

        public float Scale { get; set; }

        public Color Color { get; set; }

        public bool LockRotation { get; set; }

        #endregion Public Properties

        public override void Initialise()
        {
            originalRotation = Rotation;
            LockRotation = true;
            base.Initialise();
        }

        public override void Update()
        {
            base.Update();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (LockRotation)
            {
                spriteBatch.Draw(Texture, Position, null, Color, Parent.Rotation + originalRotation, Origin, Scale, SpriteEffects.None, 1);
            }
            else
            {
                spriteBatch.Draw(Texture, Position, null, Color, Rotation, Origin, Scale, SpriteEffects.None, 1);
            }
        }
    }
}