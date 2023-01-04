using Microsoft.Xna.Framework.Graphics;

namespace CloudyBeeEngine.WorldSpace
{
    public class Map
    {
        private int mapWidth;
        private int mapHeight;
        private Tile[,] tileMap;

        public Map()
        {
            tileMap = new Tile[mapWidth, mapHeight];
        }

        public void Draw(SpriteBatch spriteBatch)
        {
        }
    }
}