using CloudyBeeEngine.Addons;
using CloudyBeeEngine.Constants;
using CloudyBeeEngine.EntitySystem;
using CloudyBeeEngine.Factories;
using CloudyBeeEngine.Logging;
using CloudyBeeEngine.Template;
using CloudyBeeEngine.Utility;
using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;

namespace CloudyBeeEngine.Cache
{
    public static class EntityTemplateCache
    {
        private static Cache<EntityTemplate> cache;

        internal static Cache<EntityTemplate> Cache
        {
            get
            {
                if (cache == null)
                {
                    cache = new Cache<EntityTemplate>(null);
                }

                return cache;
            }
        }

        public static void Initialise(List<AddonInfo> addons)
        {
            foreach (AddonInfo addon in addons)
            {
                List<string> files = new List<string>();

                string path = Path.Combine(addon.Directory, Constant.PATH_ENTITY_CACHE);
                Helper.GetAllFiles(path, ref files);

                files.ForEach(x => LoadEntityTemplateFromFile(x));
            }
        }

        private static void LoadEntityTemplateFromFile(string file)
        {
            string itemName = Helper.GetPathFromDirectory(file, Constant.PATH_SCRIPT_CACHE);

            try
            {
                string entityDefinition = File.ReadAllText(file);
                XmlDocument entityXML = new XmlDocument();
                entityXML.LoadXml(entityDefinition);

                //Need to passs in first child node to get rid of the outer XML.
                EntityTemplate template = GameObjectFactory.GetGameObject<EntityTemplate>(entityXML.ChildNodes[0]);
                AddItem(template.Name, template);
            }
            catch (Exception ex)
            {
                Logger.Instance.LogError(string.Format("Unable to load Script from file at path '{0}'.", file));
            }
        }

        internal static bool AddItem(string entityName, EntityTemplate entityTemplate)
        {
            return Cache.AddItem(entityName, entityTemplate);
        }

        public static EntityTemplate GetItem(string entityTemplateName)
        {
            EntityTemplate value;

            if (!Cache.GetItem(entityTemplateName, out value))
            {
                return null;
            }

            return value;
        }
    }
}