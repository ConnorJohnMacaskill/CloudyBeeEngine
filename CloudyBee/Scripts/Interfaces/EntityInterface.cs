using CloudyBeeEngine.EntitySystem;
using CloudyBeeEngine.EntitySystem.Components;
using MoonSharp.Interpreter;
using System.Diagnostics;

namespace CloudyBeeEngine.LUA.Interfaces
{
    [MoonSharpUserData]
    internal class EntityInterface
    {
        private Entity entity;

        public EntityInterface(Entity entity)
        {
            this.entity = entity;
        }

        public float Rotation
        {
            get
            {
                return entity.Rotation;
            }
            set
            {
                entity.Rotation = value;
            }
        }

        public void Move(float x, float y)
        {
            entity.Move(x, y);
        }

        public void Rotate(float degree)
        {
            entity.Rotation += degree;
        }

        public void Print()
        {
            Debug.WriteLine("Thinbgy");
        }

        public SpriteComponentInterface GetSpriteComponent()
        {
            return new SpriteComponentInterface(entity.GetComponent<SpriteComponent>());
        }

        public SpriteComponentInterface GetSpriteComponent(string name)
        {
            return new SpriteComponentInterface(entity.GetComponent<SpriteComponent>(name));
        }
    }
}