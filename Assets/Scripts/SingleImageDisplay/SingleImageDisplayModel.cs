using Codebase.MVC;
using Gallery.FlickrAPIIntegration.Mediator;
using Gallery.Singletons;
using UnityEngine;

namespace Gallery.GUI
{
    public class SingleImageDisplayModel : BaseModel<SingleImageDisplayView>
    {
        private SingleImageData ImageData { get; set; }
        private ImageRequest CurrentImageRequest { get; set; }

        public void Initialize (SingleImageData imageData)
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
            if (ImageData.ThumbnailSprite != null)
            {
                SetSpriteSource(ImageData.ThumbnailSprite);
            }
            else
            {
                CurrentView.SetLoadingActive(true);
                CurrentImageRequest = SingletonContainer.Instance.NetworkingMediatorInstance.RequestImageFromUrl(ImageData.ThumbnailUrl, SetSpriteSource);
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
