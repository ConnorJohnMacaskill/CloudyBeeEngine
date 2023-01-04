using CloudyBeeEngine.Cache;
using CloudyBeeEngine.Extensions;
using CloudyBeeEngine.Logging;
using CloudyBeeEngine.Template.Components;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Xml;

namespace CloudyBeeEngine.Factories
{
    internal class PartFactory
    {
        internal static string GetStringFromXmlNode(XmlNode value, string valueName)
        {
            string result = string.Empty;

            bool success = value.TryGetInnerText(valueName, out result);

            if(!success)
            {
                Logger.Instance.LogError(string.Format("Unable to parse '{0}' as a string!", valueName));
            }

            return result;
        }

        internal static bool GetBoolFromXmlNode(XmlNode value, string valueName)
        {
            bool result = false;

            string nodeText;
            bool success = value.TryGetInnerText(valueName, out nodeText);

            if (success)
            {
                success = bool.TryParse(nodeText, out result);
            }

            if (!success)
            {
                Logger.Instance.LogError(string.Format("Unable to find texture '{0}'", value));
            }

            return result;
        }

        internal static Texture2D GetTexture2DFromXmlNode(XmlNode value, string valueName)
        {
            Texture2D result = null;

            string nodeText;
            bool success = value.TryGetInnerText(valueName, out nodeText);

            if (success)
            {
                result = TextureCache.GetItem(nodeText);
            }

            if (!success)
            {
                Logger.Instance.LogError(string.Format("Unable to find texture '{0}'", value));
            }

            return result;
        }

        internal static Vector2 GetVector2FromXmlNode(XmlNode value, string valueName)
        {
            Vector2 result = Vector2.Zero;

            string nodeText;
            bool success = value.TryGetInnerText(valueName, out nodeText);

            if (success)
            {
                success = result.TryParse(nodeText, out result);
            }

            if (!success)
            {
                Logger.Instance.LogError(string.Format("Unable to parse '{0}' as a Vector2!", nodeText));
            }

            return result;
        }

        internal static float GetFloatFromXmlNode(XmlNode value, string valueName)
        {
            float result = 0;

            string nodeText;
            bool success = value.TryGetInnerText(valueName, out nodeText);

            if (success)
            {
                success = float.TryParse(nodeText, out result);
            }
            if (!success)
            {
                Logger.Instance.LogError(string.Format("Unable to parse '{0}' as a float!", nodeText));
            }

            return result;
        }

        internal static Color GetColorFromXmlNode(XmlNode value, string valueName)
        {
            Color result = Color.White;

            string nodeText;
            bool success = value.TryGetInnerText(valueName, out nodeText);

            if (success)
            {
                success = result.TryParse(nodeText, out result);
            }

            if (!success)
            {
                Logger.Instance.LogError(string.Format("Unable to parse '{0}' as a Color!", nodeText));
            }

            return result;
        }

        internal static List<ComponentTemplate> GetComponentsFromXmlNode(XmlNode value, string valueName)
        {
            List<ComponentTemplate> result = new List<ComponentTemplate>();

            if (value[valueName] != null)
            {
                foreach (XmlNode xmlNode in value[valueName].ChildNodes)
                {
                    switch (xmlNode.Name)
                    {
                        case "SpriteComponent":
                            result.Add(GameObjectFactory.GetGameObject<SpriteComponentTemplate>(xmlNode));
                            break;
                        case "LogicComponent":
                            result.Add(GameObjectFactory.GetGameObject<LogicComponentTemplate>(xmlNode));
                            break;
                    }
                }
            }

            return result;
        }
    }
}