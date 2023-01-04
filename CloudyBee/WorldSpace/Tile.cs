using Microsoft.Xna.Framework.Graphics;

namespace CloudyBeeEngine.WorldSpace
{
    public class Tile
    {
        private int id;
        private Texture2D texture;
        private bool passable;

        public Tile(int id)
        {
            this.id = id;
        }

        public int ID
        {
            get
            {
                return id;
            }
            set
            {
                id = value;
            }
        }

        public Texture2D Texture
        {
            get
            {
                return texture;
            }
            set
            {
                texture = value;
            }
        }

        public bool Passable
        {
            get
            {
                return passable;
            }
            set
            {
                passable = false;
            }
        }
    }
}