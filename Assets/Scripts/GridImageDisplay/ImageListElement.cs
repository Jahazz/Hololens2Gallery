using Codebase.MVC.List;
using Gallery.FlickrAPIIntegration.Mediator;
using Gallery.Singletons;
using UnityEngine;

namespace Gallery.GUI
{
    public class ImageListElement : ListElement<ImageListElementData>
    {
        [field: SerializeField]
        private SpriteRenderer RendererInstance { get; set; }
        [field: SerializeField]
        private GameObject SpinnerInstance { get; set; }

        private ImageListElementData ElementData { get; set; }
        private ImageRequest CurrentImageRequest { get; set; }

        public override void Initialize (ImageListElementData elementData)
        {
            ElementData = elementData;
        }

        public void HandleOnElementClick ()
        {

        }

        protected virtual void OnEnable ()
        {
            InitializeRenderer();
        }

        private void InitializeRenderer ()
        {
            SetSpinnerActive(true);
            CurrentImageRequest = SingletonContainer.Instance.NetworkingMediatorInstance.RequestImageFromUrl(ElementData.ThumbnailUrl, SetSpriteSource);
        }

        private void SetSpriteSource (Sprite sourceImage)
        {
            if (sourceImage != null)
            {
                ElementData.ThumbnailSprite = sourceImage;
                RendererInstance.sprite = ElementData.ThumbnailSprite;
                SetSpinnerActive(false);
            }
        }

        private void SetSpinnerActive (bool isActive)
        {
            SpinnerInstance.SetActive(isActive);
            RendererInstance.gameObject.SetActive(!isActive);
        }

        protected virtual void OnDestroy ()
        {
            CurrentImageRequest.AbortRequest();
        }
    }
}
