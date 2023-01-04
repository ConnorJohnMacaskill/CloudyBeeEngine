using Microsoft.Xna.Framework.Graphics;

namespace CloudyBeeEngine.Scenes
{
    public abstract class Scene
    {
        protected string name;

        #region Public Properties

        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
            }
        }

        #endregion Public Properties

        #region Public Methods

        public abstract void Update();

        public abstract void Draw(SpriteBatch spriteBatch);

        #endregion Public Methods
    }
}