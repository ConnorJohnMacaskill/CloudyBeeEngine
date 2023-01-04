using CloudyBeeEngine.Attributes;
using CloudyBeeEngine.EntitySystem.Components;
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using System.Linq;

namespace CloudyBeeEngine.EntitySystem
{
    public abstract class GameObject
    {
        #region Variables

        //Components that are directly attached to this gameobject.
        protected List<Component> components;

        #endregion Variables

        #region Public Properties

        public string Name { get; set; }

        public Vector2 Position { get; set; }

        public float Rotation { get; set; }

        #endregion Public Properties

        #region Public Methods

        /// <summary>
        /// Attaches a component to this gameobject.
        /// </summary>
        /// <param name="component">Component to be attached.</param>
        public void AddComponent(Component component)
        {
            component.Parent = this;
            components.Add(component);
        }

        /// <summary>
        /// Determines whether this gameobject has a component of type T attached to it.
        /// </summary>
        /// <typeparam name="T">Type of component to check for.</typeparam>
        public bool HasComponent<T>()
        {
            return components.OfType<T>().Any();
        }

        /// <summary>
        /// Returns the first component of type T attached to this gameobject.
        /// </summary>
        /// <typeparam name="T">Type of component to retrieve.</typeparam>
        public T GetComponent<T>()
        {
            if (HasComponent<T>())
            {
                return components.OfType<T>().FirstOrDefault();
            }

            return default(T);
        }

        /// <summary>
        /// Returns the first component of type T attached to this gameobject.
        /// </summary>
        /// <typeparam name="T">Type of component to retrieve.</typeparam>
        /// <param name="name">Name of the component to retrieve.</param>
        /// <returns></returns>
        public T GetComponent<T>(string name)
        {
            if (components.OfType<T>().Any())
            {
                Component component = components.Where(x => x.Name == name).FirstOrDefault();

                if (component != null)
                {
                    return (T)(object)component;
                }
            }

            return default(T);
        }

        #endregion Public Methods
    }
}