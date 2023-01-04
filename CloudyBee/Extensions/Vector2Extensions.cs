using Microsoft.Xna.Framework;

namespace CloudyBeeEngine.Extensions
{
    public static class Vector2Extensions
    {
        public static bool TryParse(this Vector2 vector, string value, out Vector2 result)
        {
            bool success = false;
            string[] parts = value.Split(',');
            result = Vector2.Zero;

            if (parts.Length == 2)
            {
                float x, y;

                success = float.TryParse(parts[0], out x);
                success = float.TryParse(parts[1], out y);

                if (success)
                {
                    result = new Vector2(x, y);
                }
            }

            return success;
        }
    }
}