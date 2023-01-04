using CloudyBeeEngine.Attributes;
using CloudyBeeEngine.EntitySystem.Components;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudyBeeEngine.Template.Components
{
    public abstract class ComponentTemplate : GameObjectTemplate
    {
        [XmlInitialised(true, false)]
        public Vector2 Offset { get; set; }

        public abstract Component GetComponent(); 
    }
}
