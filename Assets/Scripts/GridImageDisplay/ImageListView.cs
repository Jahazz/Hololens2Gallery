using Codebase.MVC.List;
using Microsoft.MixedReality.Toolkit.UI;
using UnityEngine;
using UnityEngine.UI;

namespace Gallery.GUI
{
    public class ImageListView : ListView<ImageListElement, SingleImageData>
    {
        [field: SerializeField]
        private ProgressIndicatorOrbsRotator SpinnerInstance { get; set; }
        [field: SerializeField]
        private GameObject ListInstance { get; set; }
        [field: SerializeField]
        private AudioSource AudioSourceInstance { get; set; }
        [field: SerializeField]
        private ScrollRect ScrollRectInstance { get; set; }

        public void SetSpinnerActive (bool isEnabled)
        {
            SpinnerInstance.gameObject.SetActive(isEnabled);

            if (isEnabled)
            {
                SpinnerInstance.OpenAsync();
            }
            else
            {
                SpinnerInstance.CloseAsync();
            }

            if (isEnabled == false)
            {
                ListInstance.transform.localPosition = Vector3.zero;
                ListInstance.SetActive(!isEnabled);
            }
        }

        public override ImageListElement AddNewItem (SingleImageData elementData)
        {
            ImageListElement output = base.AddNewItem(elementData);

            output.InitializeAudio(AudioSourceInstance);
            output.InitializeScrollRect(ScrollRectInstance);

            return output;
        }
    }
}
