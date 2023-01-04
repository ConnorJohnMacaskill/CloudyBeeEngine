using Microsoft.Xna.Framework.Graphics;
using System.Linq;

namespace CloudyBeeEngine.Scenes
{
    public class SceneManager
    {
        private Scene currentScene;
        private Scene[] scenes;

        public SceneManager(Scene[] scenes)
        {
            this.scenes = scenes;
        }

        public void ChangeScene(string sceneName)
        {
            currentScene = scenes.Where(x => x.Name == sceneName).FirstOrDefault();
        }

        public void Update()
        {
            currentScene.Update();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            currentScene.Draw(spriteBatch);
        }
    }
}