using System;

namespace CloudyBeeEngine.Attributes
{
    internal class XmlInitialisedAttribute : Attribute
    {
        public XmlInitialisedAttribute(bool initialise, bool required)
        {
            Initialise = initialise;
        }

        #region Public Properties

        public bool Initialise { get; }
        public bool Required { get; }

        #endregion Public Properties
    }
}