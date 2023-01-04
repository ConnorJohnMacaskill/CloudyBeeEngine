using CloudyBeeEngine.Cache;
using CloudyBeeEngine.EntitySystem.Components;
using Microsoft.Xna.Framework;
using MoonSharp.Interpreter;
using System;

namespace CloudyBeeEngine.LUA.Interfaces
{
    [MoonSharpUserData]
    internal class SpriteComponentInterface
    {
        private SpriteComponent spriteComponent;

        internal SpriteComponentInterface(SpriteComponent spriteComponent)
        {
            this.spriteComponent = spriteComponent;
        }

        public void SetTexture(string textureName)
        {
            spriteComponent.Texture = TextureCache.GetItem(textureName);
        }

        public void SetOrigin(int x, int y)
        {
            spriteComponent.Origin = new Vector2(x, y);
        }

        public void LockRotation(bool lockRotation)
        {
            spriteComponent.LockRotation = lockRotation;
        }

        public void PointAtPosition(int x, int y)
        {
            float XDis = (spriteComponent.Position.X - x);
            float YDis = (spriteComponent.Position.Y - y);
            spriteComponent.Rotation = (float)Math.Atan2(-YDis, -XDis);
        }

        public void Rotate(float degrees)
        {
            spriteComponent.Rotation += degrees;
        }
    }
}