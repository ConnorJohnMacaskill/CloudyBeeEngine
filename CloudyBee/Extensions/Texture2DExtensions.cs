using Microsoft.Xna.Framework.Graphics;
using System;
using System.IO;

namespace CloudyBeeEngine.Extensions
{
    public static class Texture2DExtensions
    {
        public static bool TryParse(this Texture2D texture, string filePath, GraphicsDevice graphicsDevice, out Texture2D result)
        {
            result = null;
            bool success = false;

            try
            {
                using (FileStream stream = new FileStream(filePath, FileMode.Open))
                {
                    result = Texture2D.FromStream(graphicsDevice, stream);
                    success = true;
                }
            }
            catch (Exception ex)
            {
                //TODO: Do I want to just swallow the exception and return false?
                success = false;
            }

            return success;
        }
    }
}