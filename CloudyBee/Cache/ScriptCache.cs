using CloudyBeeEngine.Addons;
using CloudyBeeEngine.Constants;
using CloudyBeeEngine.Logging;
using CloudyBeeEngine.Utility;
using Microsoft.Xna.Framework;
using MoonSharp.Interpreter;
using System;
using System.Collections.Generic;
using System.IO;

namespace CloudyBeeEngine.Cache
{
    public class ScriptCache
    {
        private static Cache<Script> cache;

        internal static Cache<Script> Cache
        {
            get
            {
                if (cache == null)
                {
                    UserData.RegisterType<Vector2>();
                    UserData.RegisterAssembly();
                    cache = new Cache<Script>(null);
                }

                return cache;
            }
        }

        public static void Initialise(List<AddonInfo> addons)
        {
            foreach (AddonInfo addon in addons)
            {
                List<string> files = new List<string>();

                string path = Path.Combine(addon.Directory, Constant.PATH_SCRIPT_CACHE);
                Helper.GetAllFiles(path, ref files);

                files.ForEach(x => LoadScriptFromFile(x));
            }
        }

        private static void LoadScriptFromFile(string file)
        {
            string itemName = Helper.GetPathFromDirectory(file, Constant.PATH_SCRIPT_CACHE);

            try
            {
                string scriptText = File.ReadAllText(file);
                Script script = new Script();
                script.DoString(scriptText);

                AddItem(itemName, script);
            }
            catch (Exception ex)
            {
                Logger.Instance.LogError(string.Format("Unable to load Script from file at path '{0}'.", file));
            }
        }

        public static bool AddItem(string scriptName, Script script)
        {
            return Cache.AddItem(scriptName, script);
        }

        public static Script GetScript(string scriptName)
        {
            Script value;

            if (!Cache.GetItem(scriptName, out value))
            {
                value = null;// Constants.DEFAULT_SCRIPT;
            }

            return value;
        }
    }
}