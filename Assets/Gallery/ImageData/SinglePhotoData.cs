using Gallery.FlickrAPIIntegration.Endpoints;
using UnityEngine;

namespace Gallery.Data
{
    public class SinglePhotoData
    {
        public ImageData ThumbnailImage { get; set; }
        public ImageData ProperImage { get; set; }
        public string Title { get; private set; }
        public ulong ID { get; private set; }

        public SinglePhotoData (Photo sourcePhotoData)
        {
            ThumbnailImage = new ImageData(sourcePhotoData.ThumbnailUrl);
            ProperImage = new ImageData(sourcePhotoData.MediumUrl);
            ID = sourcePhotoData.ID;
            Title = sourcePhotoData.Title;
        }

        public SinglePhotoData (ImageData thumbnailImage, ImageData properImage, string title, ulong id)
        {
            ThumbnailImage = thumbnailImage;
            ProperImage = properImage;
            Title = title;
            ID = id;
        }
    }
}
