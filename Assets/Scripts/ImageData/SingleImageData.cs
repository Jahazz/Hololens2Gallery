using Gallery.FlickrAPIIntegration.Endpoints;
using UnityEngine;

namespace Gallery.Data
{
    public class SingleImageData
    {
        public Sprite ThumbnailSprite { get; set; }
        public Sprite MediumSprite { get; set; }
        public string ThumbnailUrl { get; private set; }
        public string MediumUrl { get; private set; }
        public string Title { get; private set; }
        public ulong ID { get; private set; }

        public SingleImageData (Photo sourcePhotoData)
        {
            ThumbnailUrl = sourcePhotoData.ThumbnailUrl;
            MediumUrl = sourcePhotoData.MediumUrl;
            ID = sourcePhotoData.ID;
            Title = sourcePhotoData.Title;
        }

        public SingleImageData(Sprite sprite)
        {
            MediumSprite = sprite;
        }
    }
}
