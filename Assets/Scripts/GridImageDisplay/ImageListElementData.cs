using Gallery.FlickrAPIIntegration.Endpoints;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Gallery.GUI
{
    public class ImageListElementData
    {
        public Sprite ThumbnailSprite { get; set; }
        public Sprite MediumSprite { get; set; }
        public string ThumbnailUrl { get; private set; }
        public string MediumUrl { get; private set; }

        public ImageListElementData (Photo sourcePhotoData)
        {
            ThumbnailUrl = sourcePhotoData.ThumbnailUrl;
            MediumUrl = sourcePhotoData.MediumUrl;
        }
    }
}
