using Microsoft.Xna.Framework;

namespace CloudyBeeEngine.Extensions
{
    public static class ColorExtensions
    {
        public static bool TryParse(this Color vector, string value, out Color result)
        {
            bool success = false;
            string[] parts = value.Split(',');
            result = Color.White;

            if (parts.Length == 4)
            {
                byte r, g, b, a;

                success = byte.TryParse(parts[0], out r);
                success = byte.TryParse(parts[1], out g);
                success = byte.TryParse(parts[2], out b);
                success = byte.TryParse(parts[3], out a);

                if (success)
                {
                    result = new Color(r, g, b, a);
                }
            }
            else if (parts.Length == 1)
            {
                var colorProp = typeof(Color).GetProperty(parts[0]);

                if (colorProp != null)
                {
                    result = (Color)colorProp.GetValue(null);
                    success = true;
                }
            }

            return success;
        }
    }
}