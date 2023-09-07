using UnityEngine;

namespace Gallery.Data
{
    public class ImageData : MonoBehaviour
    {
        public string Url { get; private set; }
        public Sprite Sprite { get; set; }

        public ImageData (string url)
        {
            Url = url;
        }
    }
}
