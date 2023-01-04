using CloudyBeeEngine.EntitySystem;
using CloudyBeeEngine.EntitySystem.Components;
using CloudyBeeEngine.Template;
using CloudyBeeEngine.Template.Components;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudyBeeEngine.Factories
{
    public static class EntityFactory
    {
        public static Entity GetEntity(EntityTemplate entityTemplate)
        {
            Entity entity = new Entity()
            {
                Name = entityTemplate.Name,
                Position = Vector2.Zero,
                Rotation = 0f
            };

            GetComponents(entityTemplate.Components).ForEach(x => entity.AddComponent(x));

            entity.Initialise();

            return entity;
        }

        private static List<Component> GetComponents(List<ComponentTemplate> componentTemplates)
        {
            List<Component> components = new List<Component>();

            componentTemplates.ForEach(x => components.Add(x.GetComponent()));

            return components;
        }
    }
}
