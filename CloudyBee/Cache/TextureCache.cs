using CloudyBeeEngine.Addons;
using CloudyBeeEngine.Constants;
using CloudyBeeEngine.Extensions;
using CloudyBeeEngine.Logging;
using CloudyBeeEngine.Utility;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using System.IO;

namespace CloudyBeeEngine.Cache
{
    public static class TextureCache
    {
        private static Cache<Texture2D> cache;
        private static Texture2D missingTexture;

        internal static Cache<Texture2D> Cache
        {
            get
            {
                if (cache == null)
                {
                    cache = new Cache<Texture2D>(null);
                }

                return cache;
            }
        }

        public static void Initialise(List<AddonInfo> addons, GraphicsDevice graphics, Texture2D defaultTexture)
        {
            missingTexture = defaultTexture;

            foreach (AddonInfo addon in addons)
            {
                List<string> files = new List<string>();

                string path = Path.Combine(addon.Directory, Constant.PATH_TEXTURE_CACHE);
                Helper.GetAllFiles(path, ref files);

                files.ForEach(x => LoadTextureFromFile(x, graphics));
            }
        }

        private static void LoadTextureFromFile(string file, GraphicsDevice graphics)
        {
            Texture2D texture = null;
            string itemName = Helper.GetPathFromDirectory(file, Constant.PATH_TEXTURE_CACHE);

            bool success = texture.TryParse(file, graphics, out texture);

            if (success)
            {
                AddItem(itemName, texture);
            }
            else
            {
                Logger.Instance.LogError(string.Format("Unable to load Texture from file at path '{0}'.", file));
            }
        }

        public static bool AddItem(string textureName, Texture2D texture)
        {
            return Cache.AddItem(textureName, texture);
        }

        public static Texture2D GetItem(string textureName)
        {
            Texture2D value;

            if (!Cache.GetItem(textureName, out value))
            {
                value = missingTexture;
            }

            return value;
        }
    }
}