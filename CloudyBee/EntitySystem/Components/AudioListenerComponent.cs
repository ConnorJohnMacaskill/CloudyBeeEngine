using CloudyBeeEngine.Template.Components;
using Microsoft.Xna.Framework.Audio;

namespace CloudyBeeEngine.EntitySystem.Components
{
    public class AudioListenerComponent : Component
    {
        public AudioListenerComponent(AudioListenerComponentTemplate audioListenerComponentTemplate) : base()
        {
            Name = audioListenerComponentTemplate.Name;
            AudioListener = audioListenerComponentTemplate.AudioListener;
            OffSet = audioListenerComponentTemplate.Offset;
        }

        #region Public Properties

        public AudioListener AudioListener { get; set; }

        #endregion Public Properties

        public override void Initialise()
        {
            base.Initialise();
        }
    }
}