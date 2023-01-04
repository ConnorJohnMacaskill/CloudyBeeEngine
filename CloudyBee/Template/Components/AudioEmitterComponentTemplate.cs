using CloudyBeeEngine.Attributes;
using Microsoft.Xna.Framework.Audio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CloudyBeeEngine.EntitySystem.Components;

namespace CloudyBeeEngine.Template.Components
{
    public class AudioEmitterComponentTemplate : ComponentTemplate
    {
        #region Public Properties

        [XmlInitialised(false, false)]
        public AudioEmitter AudioEmitter { get; set; }

        #endregion Public Properties

        #region Public Methods

        public override Component GetComponent()
        {
            return new AudioEmitterComponent(this);
        }

        #endregion Public Methods
    }
}
