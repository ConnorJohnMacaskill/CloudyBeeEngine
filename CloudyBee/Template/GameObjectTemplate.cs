using CloudyBeeEngine.Attributes;
using CloudyBeeEngine.Template.Components;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudyBeeEngine.Template
{
    public abstract class GameObjectTemplate
    {
        [XmlInitialised(true, true)]
        public string Name { get; set; }

        [XmlInitialised(false, false)]
        public Vector2 Position { get; set; }

        [XmlInitialised(true, false)]
        public float Rotation { get; set; }

        [XmlInitialised(true, false)]
        public List<ComponentTemplate> Components { get; set; }
    }
}
