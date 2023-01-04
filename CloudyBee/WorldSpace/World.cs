using CloudyBeeEngine.EntitySystem;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace CloudyBeeEngine.WorldSpace
{
    public class World
    {
        private Map map;
        private List<Entity> entities;

        public World()
        {
            map = new Map();
            entities = new List<Entity>();
        }

        public void AddEntity(Entity entity, Vector2 position)
        {
            entity.Position = position;
            entities.Add(entity);
        }

        public void Update()
        {
            //We want to update all of our world entities.
            entities.ForEach(x => x.Update());
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            //Draw our beautiful map.
            map.Draw(spriteBatch);
            //Draw all the entities in our world.
            entities.ForEach(x => x.Draw(spriteBatch));
        }
    }
}