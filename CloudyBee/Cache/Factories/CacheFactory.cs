using CloudyBee.Addons;
using CloudyBee.Constants;
using CloudyBee.Extensions;
using CloudyBee.Logging;
using CloudyBee.Utility;
using Microsoft.Xna.Framework.Graphics;
using MoonSharp.Interpreter;
using System;
using System.Collections.Generic;
using System.IO;

namespace CloudyBee.Cache.Factories
{
    public static class CacheFactory
    {


        public static void Initialise(Texture2D missingTexture)
        {
            //TextureCache.MissingTexture = missingTexture;
        }

        public static void LoadScriptCacheForAddon(Addon addon)
        {
            string path = Path.Combine(addon.Directory, Constant.PATH_SCRIPT_CACHE);
            LoadScriptsInDirectory(path);
        }


        private static void LoadScriptsInDirectory(string directory)
        {
            List<string> files = new List<string>();

            Helper.GetAllFiles(directory, ref files);

            files.ForEach(x => LoadScriptFromFile(x));
        }


        private static void LoadScriptFromFile(string file)
        {
            string itemName = GetScriptName(file);

            try
            {
                string scriptText = File.ReadAllText(file);
                Script script = new Script();
                script.DoString(scriptText);

                ScriptCache.AddItem(itemName, script);
            }
            catch (Exception ex)
            {
                Logger.Instance.LogError(string.Format("Unable to load Script from file at path '{0}'.", file));
            }
        }

        private static string GetScriptName(string file)
        {
            FileInfo fileInfo = new FileInfo(file);
            string name = file.Replace("\\", "/").Replace(fileInfo.Extension, "");
            int startIndex = name.IndexOf(Constant.PATH_SCRIPT_CACHE) + Constant.PATH_SCRIPT_CACHE_CHAR_LENGTH + 1;
            int length = name.Length - startIndex;
            name = name.Substring(startIndex, length);
            return name;
        }
    }
}