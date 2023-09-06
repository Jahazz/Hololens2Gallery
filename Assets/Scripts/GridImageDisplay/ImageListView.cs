using Codebase.MVC.List;
using Microsoft.MixedReality.Toolkit.UI;
using Microsoft.MixedReality.Toolkit.Utilities;
using System.Collections;
using UnityEngine;

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

            ListInstance.SetActive(!isEnabled);
        }

        public override ImageListElement AddNewItem (SingleImageData elementData)
        {
            ImageListElement output = base.AddNewItem(elementData);
            output.InitializeAudio(AudioSourceInstance);
            return output;
        }
    }
}
