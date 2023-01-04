using System.Xml;

namespace CloudyBeeEngine.Extensions
{
    public static class XmlNodeExtensions
    {
        public static bool TryGetInnerText(this XmlNode node, string key, out string value)
        {
            bool success = false;
            value = string.Empty;

            if (node != null)
            {
                //TODO When I eventually get internet (oh god its so annoying) see if this can be changed to be case insensitive.
                if (node[key] != null)
                {
                    value = node[key].InnerText;
                    success = true;
                }
            }

            return success;
        }
    }
}