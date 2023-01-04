using CloudyBeeEngine.Cache;
using Microsoft.Xna.Framework.Graphics;
using MoonSharp.Interpreter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudyBee.Factories
{
    internal static class CacheFactory
    {

        internal static Cache<T> GetCache<T>(string rootDirectory)
        {
            Cache<T> cache;

            //Get all file names.
            //Get default item from config.
            //Attempt to parse every file, switch on type.
            var thing = GetItemsFromFiles<Texture2D>(new List<string>());
            return null;
        }

        private static List<T> GetItemsFromFiles<T>(List<string> files)
        {
            string typeName = typeof(T).Name;

            switch (typeName)
            {
                case "Texture":
                    break;
                case "string":
                    break;
                case "EntityTemplate":
                    break;
            }

            return null;
        }

        private static DynValue GetDynValue(string file)
        {
            script.Globals["Input"] = typeof(InputInterface);
        }
    }
}
