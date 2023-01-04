using CloudyBeeEngine.Attributes;
using CloudyBeeEngine.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Xml;

namespace CloudyBeeEngine.Factories
{
    public static class GameObjectFactory
    {
        public static T GetGameObject<T>(XmlNode xmlNode)
        {
            //Get the properties of the type of Component we want to get.
            Type componentType = typeof(T);
            PropertyInfo[] componentProperties = componentType.GetProperties();
            T component = (T)Activator.CreateInstance(componentType);
            //Filter the properties so we only attempt to load the ones which should be loaded from XML.
            List<PropertyInfo> filteredProperties = componentProperties.Where(x => x.GetCustomAttribute<XmlInitialisedAttribute>().Initialise).ToList();

            filteredProperties.ForEach(x => x.SetValue(component, GetPart(xmlNode, x)));

            return component;
        }

        internal static object GetPart(XmlNode value, PropertyInfo property)
        {
            object result = new object();

            //I dislike this switch, but oh well. Its not exacty hard to add a case if I add more part types in the future.
            switch (property.PropertyType.Name)
            {
                case "String":
                    result = PartFactory.GetStringFromXmlNode(value, property.Name);
                    break;

                case "Texture2D":
                    result = PartFactory.GetTexture2DFromXmlNode(value, property.Name);
                    break;

                case "Single": //AKA Float
                    result = PartFactory.GetFloatFromXmlNode(value, property.Name);
                    break;

                case "Boolean":
                    result = PartFactory.GetBoolFromXmlNode(value, property.Name);
                    break;

                case "Vector2":
                    result = PartFactory.GetVector2FromXmlNode(value, property.Name);
                    break;

                case "Color":
                    result = PartFactory.GetColorFromXmlNode(value, property.Name);
                    break;

                case "List`1":
                    result = PartFactory.GetComponentsFromXmlNode(value, property.Name);
                    break;
            }

            return result;
        }
    }
}