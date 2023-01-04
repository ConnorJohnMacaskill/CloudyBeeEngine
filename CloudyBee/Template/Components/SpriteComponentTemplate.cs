using CloudyBeeEngine.Attributes;
using CloudyBeeEngine.EntitySystem.Components;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudyBeeEngine.Template.Components
{
    public class SpriteComponentTemplate : ComponentTemplate
    {
        #region Public Properties

        [XmlInitialised(true, true)]
        public string Texture { get; set; }

        [XmlInitialised(true, true)]
        public Vector2 Origin { get; set; }

        [XmlInitialised(true, false)]
        public float Scale { get; set; }

        [XmlInitialised(true, false)]
        public Color Color { get; set; }

        [XmlInitialised(true, false)]
        public bool LockRotation { get; set; }

        #endregion Public Properties

        #region Public Methods

        public override Component GetComponent()
        {
            return new SpriteComponent(this);
        }

        #endregion Public Methods
    }
}
