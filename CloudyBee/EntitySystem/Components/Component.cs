using CloudyBeeEngine.Attributes;
using Microsoft.Xna.Framework;

namespace CloudyBeeEngine.EntitySystem.Components
{
    public abstract class Component : GameObject
    {
        public Component()
        {
        }

        /// <summary>
        ///TTODO: See if this can be improved.
        /// </summary>
        /// <param name="component"></param>
        /// <returns></returns>
        protected static Entity GetParentEntityOfComponent(GameObject component)
        {
            if (component.GetType() == typeof(Entity))
            {
                return (Entity)component;
            }
            else
            {
                return GetParentEntityOfComponent(((Component)component).Parent);
            }
        }

        public virtual void Initialise()
        {
            UpdatePositionRelativeToParent();
        }

        public virtual void Update()
        {
            //Update position relative to parent position.
            UpdatePositionRelativeToParent();
        }

        private void UpdatePositionRelativeToParent()
        {
#warning Might be worth adding a flag to check this? Only need to do this IF there is an offset.
            Matrix transform = Matrix.CreateRotationZ(Parent.Rotation);
            Position = Parent.Position + Vector2.Transform(OffSet, transform);
        }

        #region Public Properties
        
        public GameObject Parent { get; set; }
        
        public Vector2 OffSet { get; set; }

        #endregion Public Properties
    }
}