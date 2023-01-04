using CloudyBeeEngine.Utility;
using CloudyBeeEngine.WorldSpace;
using Microsoft.Xna.Framework;
using MoonSharp.Interpreter;

namespace CloudyBeeEngine.LUA.Interfaces
{
    [MoonSharpUserData]
    internal static class InputInterface
    {
        public static Vector2 GetMousePosition()
        {
            return Input.Instance.MousePosition(Camera.Instance.Transform());
        }
    }
}