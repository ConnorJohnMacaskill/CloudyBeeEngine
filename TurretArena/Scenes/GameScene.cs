using CloudyBeeEngine.Scenes;
using CloudyBeeEngine.WorldSpace;
using Microsoft.Xna.Framework.Graphics;

namespace TurretArena.Scenes
{
    internal class GameScene : Scene
    {
        private World world;

        public GameScene(string name, World world)
        {
            this.name = name;
            this.world = world;
        }

        public override void Update()
        {
            world.Update();
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            world.Draw(spriteBatch);
        }
    }
}