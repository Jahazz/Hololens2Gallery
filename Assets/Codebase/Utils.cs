using UnityEngine;

namespace Codebase.Utils
{
    public static class Utils
    {
        public static Sprite Texture2DToSprite (Texture2D source)
        {
            return Sprite.Create(source, new Rect(0.0f, 0.0f, source.width, source.height), Vector2.one / 2, 100.0f);
        }
    }
}

