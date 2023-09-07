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
            CurrentView.SetTitle(imageData.Title);
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
            if (ImageData.ProperImage.Sprite != null)
            {
                SetSpriteSource(ImageData.ProperImage.Sprite);
            }
            else
            {
                CurrentView.SetLoadingActive(true);
                CurrentImageRequest = SingletonContainer.Instance.NetworkingMediatorInstance.RequestImageFromUrl(ImageData.ProperImage.Url, SetSpriteSource);
            }
        }

        private void SetSpriteSource (Sprite sourceImage)
        {
            ImageData.ProperImage.Sprite = sourceImage;
            CurrentView.SetLoadingActive(false);
            CurrentView.SetImage(ImageData.ProperImage.Sprite);
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
