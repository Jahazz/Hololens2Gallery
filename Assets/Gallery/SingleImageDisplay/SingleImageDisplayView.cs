using Codebase.MVC;
using Microsoft.MixedReality.Toolkit.UI;
using TMPro;
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
        [field: SerializeField]
        private TMP_Text TitleLabel { get; set; }

        public void SetImage (Sprite imageSource)
        {
            ImageInstance.sprite = imageSource;
        }

        public void SetTitle (string title)
        {
            TitleLabel.text = title;
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
