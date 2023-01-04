using CloudyBee.Cache;
using CloudyBeeEngine.Addons;
using CloudyBeeEngine.Cache;
using CloudyBeeEngine.Factories;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using MoonSharp.Interpreter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudyBeeEngine
{
    public class CloudyBee2
    {
        

        public static void Initialise(GraphicsDevice graphics, ContentManager content)
        {
            List<AddonInfo> addons = AddonFactory.GetAddons();

            Texture2D missingTexture = content.Load<Texture2D>("Missing");

            ResourcePool.Initialise();
            RegisterAssembly();

            TextureCache.Initialise(addons, graphics, missingTexture);
            ScriptCache.Initialise(addons);
            EntityTemplateCache.Initialise(addons);

        }

        private static void RegisterAssembly()
        {
            UserData.RegisterType<Vector2>();
            UserData.RegisterAssembly();
        }
    }
}
