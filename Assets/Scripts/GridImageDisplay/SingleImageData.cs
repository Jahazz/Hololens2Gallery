using Gallery.FlickrAPIIntegration.Endpoints;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Gallery.GUI
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
