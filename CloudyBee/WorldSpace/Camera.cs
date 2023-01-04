using Microsoft.Xna.Framework;

namespace CloudyBeeEngine.WorldSpace
{
    public class Camera
    {
        private int screenWidth;
        private int screenHeight;
        private static Camera instance;


        public Camera(int screenWidth, int screenHeight)
        {
            this.screenWidth = screenWidth;
            this.screenHeight = screenHeight;

            Position = Vector2.Zero;
            Zoom = 1.0f;
        }

#warning I dont think this will work.
        public static Camera Instance
        {
            get
            {
                if(instance == null)
                {
                    instance = new Camera(800, 800); 
                }

                return instance;
            }
        }

        public Vector2 Position { get; set; }
        public float Zoom { get; set; }

        #region Public Methods

        public Matrix Transform()
        {
            Matrix transform = Matrix.CreateTranslation(new Vector3(Instance.Position.X, Instance.Position.Y, 0)) * Matrix.CreateScale(new Vector3(Instance.Zoom, Instance.Zoom, 1));// * Matrix.CreateTranslation(new Vector3(screenWidth/2, screenHeight/2, 0));

            return transform;
        }

        #endregion Public Methods
    }
}