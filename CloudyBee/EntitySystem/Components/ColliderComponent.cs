using CloudyBeeEngine.EntitySystem.Colliders;
using CloudyBeeEngine.Template.Components;

namespace CloudyBeeEngine.EntitySystem.Components
{
    public class ColliderComponent : Component
    {
        public ColliderComponent(ColliderComponentTemplate colliderComponentTemplate) : base()
        {
            Name = colliderComponentTemplate.Name;
            Collider = colliderComponentTemplate.Collider;
            OffSet = colliderComponentTemplate.Offset;
        }

        #region Public Properties

        public Collider Collider { get; set; }

        #endregion Public Properties

        public override void Initialise()
        {
            base.Initialise();
        }
    }
}