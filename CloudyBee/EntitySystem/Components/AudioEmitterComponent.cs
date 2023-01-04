using CloudyBeeEngine.Template.Components;
using Microsoft.Xna.Framework.Audio;

namespace CloudyBeeEngine.EntitySystem.Components
{
    public class AudioEmitterComponent : Component
    {
        public AudioEmitterComponent(AudioEmitterComponentTemplate audioEmitterComponentTemplate) : base()
        {
            Name = audioEmitterComponentTemplate.Name;
            AudioEmitter = audioEmitterComponentTemplate.AudioEmitter;
            OffSet = audioEmitterComponentTemplate.Offset;
        }

        #region Public Properties

        public AudioEmitter AudioEmitter { get; set; }

        #endregion Public Properties

        #region Public Methods

        public override void Initialise()
        {
            base.Initialise();
        }

        #endregion Public Methods
    }
}