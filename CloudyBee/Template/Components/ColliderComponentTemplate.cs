using CloudyBeeEngine.Attributes;
using CloudyBeeEngine.EntitySystem.Colliders;
using CloudyBeeEngine.EntitySystem.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudyBeeEngine.Template.Components
{
    public class ColliderComponentTemplate : ComponentTemplate
    {
        #region Public Properties

        [XmlInitialised(true, true)]
        public Collider Collider { get; set; }

        #endregion Public Properties

        #region Public Methods

        public override Component GetComponent()
        {
            return new ColliderComponent(this);
        }

        #endregion Public Methods
    }
}
