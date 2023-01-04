using CloudyBeeEngine.Attributes;
using CloudyBeeEngine.EntitySystem.Components;
using Microsoft.Xna.Framework.Audio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudyBeeEngine.Template.Components
{
    public class AudioListenerComponentTemplate : ComponentTemplate
    {
        #region Public Properties

        [XmlInitialised(false, false)]
        public AudioListener AudioListener { get; set; }

        #endregion Public Properties

        #region Public Methods

        public override Component GetComponent()
        {
            return new AudioListenerComponent(this);
        }

        #endregion Public Methods
    }
}
