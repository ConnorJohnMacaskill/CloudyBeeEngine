using System;
using System.Collections.Generic;
using CloudyBeeEngine.Template.Components;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CloudyBeeEngine.Attributes;
using CloudyBeeEngine.EntitySystem.Components;

namespace CloudyBeeEngine.Template.Components
{
    public class LogicComponentTemplate : ComponentTemplate
    {
        [XmlInitialised(true, true)]
        public string Script { get; set; }

        #region Public Methods

        public override Component GetComponent()
        {
            return new LogicComponent(this);
        }

        #endregion Public Methods
    }
}
