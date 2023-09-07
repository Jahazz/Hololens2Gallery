using UnityEngine;

namespace Gallery.Data
{
    public class ImageData
    {
        public string Url { get; private set; }
        public Sprite Sprite { get; set; }

        public ImageData (string url)
        {
            Url = url;
        }
    }
}
