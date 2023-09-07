using Codebase.MVC;
using UnityEngine;
using Gallery.FlickrAPIIntegration.Mediator;
using Gallery.Singletons;
using Gallery.Data;

namespace Gallery.GUI
{
    public class SingleImageDisplayModel : BaseModel<SingleImageDisplayView>
    {
        private SinglePhotoData ImageData { get; set; }
        private ImageRequest CurrentImageRequest { get; set; }

        public void Initialize (SinglePhotoData imageData)
        {
            ImageData = imageData;
            InitializeRenderer();
        }

        protected virtual void OnDestroy ()
        {
            CurrentImageRequest?.AbortRequest();
        }

        protected virtual void Update ()
        {
            UpdateProgressIfNeeded();
        }

        private void InitializeRenderer ()
        {
            if (ImageData.ThumbnailImage.Sprite != null)
            {
                SetSpriteSource(ImageData.ThumbnailImage.Sprite);
            }
            else
            {
                CurrentView.SetLoadingActive(true);
                CurrentImageRequest = SingletonContainer.Instance.NetworkingMediatorInstance.RequestImageFromUrl(ImageData.ThumbnailImage.Url, SetSpriteSource);
            }
        }

        private void SetSpriteSource (Sprite sourceImage)
        {
            CurrentView.SetLoadingActive(false);
            CurrentView.SetImage(sourceImage);
        }

        private void UpdateProgressIfNeeded ()
        {
            if (CurrentImageRequest != null && CurrentImageRequest.RequestProgress < 1.0f)
            {
                CurrentView.UpdateLoadingProgress(CurrentImageRequest.RequestProgress);
            }
        }
    }
}
