using CloudyBee.Factories;
using CloudyBeeEngine.Cache;
using CloudyBeeEngine.Template;
using Microsoft.Xna.Framework.Graphics;
using MoonSharp.Interpreter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudyBee.Cache
{
    internal static class ResourcePool
    {
        private static Cache<Script> scriptCache;
        private static Cache<Texture2D> textureCache;
        private static Cache<EntityTemplate> entityCache;

        #region Public Properties

        public static Cache<Script> ScriptCache
        {
            get

            {
                return scriptCache;
            }
        }

        public static Cache<Texture2D> TextureCache
        {
            get
            {
                return textureCache;
            }
        }

        public static Cache<EntityTemplate> EntityCache
        {
            get
            {
                return entityCache;
            }
        }


        #endregion Public Properties

        public static void Initialise()
        {
            //All addon resources are loaded into the resource pool, so logically the resource pool should handle the addon loading.
           // scriptCache = CacheFactory.GetCache<Script>("efdef");
        }

    }
}
