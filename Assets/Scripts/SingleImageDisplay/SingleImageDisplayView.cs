using Codebase.MVC;
using Microsoft.MixedReality.Toolkit.UI;
using UnityEngine;
using UnityEngine.UI;

namespace Gallery.GUI
{
    public class SingleImageDisplayView : BaseView
    {

        [field: SerializeField]
        private Image ImageInstance { get; set; }
        [field: SerializeField]
        private GameObject WindowGameobjectInstance { get; set; }
        [field: SerializeField]
        private ProgressIndicatorLoadingBar LoadingIndicatorInstance { get; set; }

        public void SetImage (Sprite imageSource)
        {
            ImageInstance.sprite = imageSource;
        }

        public void UpdateLoadingProgress (float value)
        {
            LoadingIndicatorInstance.Progress = value;
        }

        public void SetLoadingActive (bool isActive)
        {
            LoadingIndicatorInstance.gameObject.SetActive(isActive);
            WindowGameobjectInstance.SetActive(!isActive);
        }
    }
}
