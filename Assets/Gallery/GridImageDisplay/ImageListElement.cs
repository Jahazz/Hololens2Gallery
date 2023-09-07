using Codebase.MVC.List;
using Codebase.Utils;
using Gallery.FlickrAPIIntegration.Mediator;
using Gallery.Singletons;
using Gallery.Data;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using Codebase.EventPassing;

namespace Gallery.GUI
{
    public class ImageListElement : ListElement<SinglePhotoData>
    {
        [field: SerializeField]
        private Image ImageInstance { get; set; }
        [field: SerializeField]
        private GameObject SpinnerInstance { get; set; }

        [field: Space]
        [field: SerializeField]
        private EventTrigger EventTriggerInstance { get; set; }
        [field: SerializeField]
        private AudioClip OnPointerDownClip { get; set; }
        [field: SerializeField]
        private AudioClip OnPointerUpClip { get; set; }
        [field: SerializeField]
        private EventPasser EventPasserInstance { get; set; }

        private SinglePhotoData ElementData { get; set; }
        private ImageRequest CurrentImageRequest { get; set; }
        private AudioSource AudioSourceInstance { get; set; }

        public override void Initialize (SinglePhotoData elementData)
        {
            ElementData = elementData;
        }

        public void InitializeAudio (AudioSource audioSourceInstance)
        {
            AudioSourceInstance = audioSourceInstance;

            Utils.AddEventTriggerListener(EventTriggerInstance, EventTriggerType.PointerDown, HandleOnPointerDown);
            Utils.AddEventTriggerListener(EventTriggerInstance, EventTriggerType.PointerUp, HandleOnPointerUp);
        }

        public void InitializeScrollRect (ScrollRect scrollRectInstance)
        {
            EventPasserInstance.Initialzie(scrollRectInstance.gameObject);
        }

        public void HandleOnPointerDown (PointerEventData data)
        {
            AudioSourceInstance.PlayOneShot(OnPointerDownClip);
        }
        public void HandleOnPointerUp (PointerEventData data)
        {
            AudioSourceInstance.PlayOneShot(OnPointerUpClip);
        }

        public void HandleOnElementClick ()
        {
            SingletonContainer.Instance.UiManagerInstance.ShowSingleImage(ElementData);
        }

        protected virtual void OnEnable ()
        {
            InitializeRenderer();
        }

        private void InitializeRenderer ()
        {
            SetSpinnerActive(true);

            if (ElementData.ProperImage.Sprite != null)
            {
                SetSpriteSource(ElementData.ProperImage.Sprite);
            }
            else if (ElementData.ThumbnailImage.Sprite != null)
            {
                SetSpriteSource(ElementData.ThumbnailImage.Sprite);
            }
            else
            {
                CurrentImageRequest = SingletonContainer.Instance.NetworkingMediatorInstance.RequestImageFromUrl(ElementData.ThumbnailImage.Url, HandleThumbnailResponse);
            }
        }

        private void HandleThumbnailResponse (Sprite loadedSprite)
        {
            if (loadedSprite != null)
            {
                ElementData.ThumbnailImage.Sprite = loadedSprite;
                SetSpriteSource(ElementData.ThumbnailImage.Sprite);
            }
        }

        private void SetSpriteSource (Sprite sourceImage)
        {
            ImageInstance.sprite = sourceImage;
            SetSpinnerActive(false);
        }

        private void SetSpinnerActive (bool isActive)
        {
            SpinnerInstance.SetActive(isActive);
            ImageInstance.gameObject.SetActive(!isActive);
        }

        protected virtual void OnDestroy ()
        {
            CurrentImageRequest?.AbortRequest();
        }
    }
}
