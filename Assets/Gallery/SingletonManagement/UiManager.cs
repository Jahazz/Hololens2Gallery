using Gallery.GUI;
using Gallery.Data;
using UnityEngine;

namespace Gallery.Singletons
{
    public class UiManager : MonoBehaviour
    {
        [field: SerializeField]
        public ImageListController ImageListControllerInstance { get; private set; }
        [field: SerializeField]
        public SearchMenuController SearchMenuControllerInstance { get; private set; }

        [field: Space]
        [field: SerializeField]
        private SingleImageDisplayController SingleImagePrefab { get; set; }

        public void ShowSingleImage (SinglePhotoData imageData)
        {
            Instantiate(SingleImagePrefab).Initialize(imageData);
        }
    }
}
