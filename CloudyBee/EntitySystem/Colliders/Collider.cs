using Microsoft.Xna.Framework;

namespace CloudyBeeEngine.EntitySystem.Colliders
{
    public abstract class Collider
    {
        private Vector2 position;

        public abstract bool Collides(Collider collider);
    }
}