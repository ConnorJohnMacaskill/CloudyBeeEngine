using CloudyBeeEngine.EntitySystem.Components;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using System.Linq;

namespace CloudyBeeEngine.EntitySystem
{
    public class Entity : GameObject
    {
        public Entity()
        {
            components = new List<Component>();
        }

        #region Public Methods

        public void Initialise()
        {
            components.ForEach(x => x.Initialise());
        }

        public void Move(float x, float y)
        {
            Position += new Vector2(x, y);
        }

        public void Update()
        {
            components.ForEach(x => x.Update());
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            components.OfType<SpriteComponent>().ToList().ForEach(x => x.Draw(spriteBatch));
        }

        #endregion Public Methods
    }
}