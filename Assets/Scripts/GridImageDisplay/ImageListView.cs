using Codebase.MVC.List;
using Microsoft.MixedReality.Toolkit.UI;
using Microsoft.MixedReality.Toolkit.Utilities;
using System.Collections;
using UnityEngine;

namespace Gallery.GUI
{
    public class ImageListView : ListView<ImageListElement, ImageListElementData>
    {
        [field: SerializeField]
        private GameObject SpinnerInstance { get; set; }
        [field: SerializeField]
        private GameObject ListInstance { get; set; }
        [field: SerializeField]
        private GridObjectCollection GridCollectionInstance { get; set; }
        [field: SerializeField]
        private ScrollingObjectCollection ScrollingObjectCollectionInstance { get; set; }
        [field: SerializeField]
        private Transform ScrollableTransform { get; set; }

        public void SetSpinnerActive (bool isEnabled)
        {
            SpinnerInstance.SetActive(isEnabled);
            ListInstance.SetActive(!isEnabled);
        }

        public void UpdateCollectionVisuals ()
        {
            StartCoroutine(UpdateCoroutineInNextFrame());
        }

        private IEnumerator UpdateCoroutineInNextFrame ()
        {
            yield return 0;
            GridCollectionInstance.UpdateCollection();
            ScrollingObjectCollectionInstance.UpdateContent();
            ScrollingObjectCollectionInstance.MoveToIndex(0, false);
        }
    }
}
