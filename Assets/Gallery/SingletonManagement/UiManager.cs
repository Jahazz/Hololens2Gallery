using Gallery.GUI;
using Gallery.Data;
using UnityEngine;
using System.Collections;
using Gallery.Saving;
using System.Collections.Generic;

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

        public void ShowSearchMenu ()
        {
            SearchMenuControllerInstance.gameObject.SetActive(true);
        }

        public void Save ()
        {
            StartCoroutine(SaveCoroutine());
        }

        public void Load ()
        {
            StartCoroutine(LoadCoroutine());
        }

        private IEnumerator SaveCoroutine ()
        {
            yield return null;
            SaveOutputType saveOutput = SaveUtils.SaveCurrentPhotos(ImageListControllerInstance.GetCurrentPhotoCollection());
        }

        private IEnumerator LoadCoroutine ()
        {
            yield return null;
            List<SinglePhotoData> output;
            LoadOutputType loadOutput = SaveUtils.LoadImages(out output);

            if (loadOutput == LoadOutputType.OK)
            {
                ImageListControllerInstance.SetupCollection(output);
            }
        }
    }
}
