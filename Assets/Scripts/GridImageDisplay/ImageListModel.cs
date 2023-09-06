using Codebase.MVC.List;
using Gallery.FlickrAPIIntegration.Endpoints;
using Gallery.Saving;
using Gallery.Singletons;
using System.Collections.Generic;

namespace Gallery.GUI
{
    public class ImageListModel : ListModel<ImageListElement, SingleImageData, ImageListView>
    {
        public void GetImageList (string textToSearch, int maxImagecount)
        {
            CurrentView.SetSpinnerActive(true);
            SingletonContainer.Instance.NetworkingMediatorInstance.SearchForPhotosByName(textToSearch, maxImagecount, PopulateList);
        }

        public void PopulateList (List<Photo> sourcePhotoDataCollection)
        {
            List<SingleImageData> singleImagesCollection = new List<SingleImageData>();

            foreach (Photo sourcePhotoData in sourcePhotoDataCollection)
            {
                singleImagesCollection.Add(new SingleImageData(sourcePhotoData));
            }

            PopulateList(singleImagesCollection);
        }

        public void PopulateList (List<SingleImageData> sourcePhotoDataCollection)
        {
            CurrentView.ClearList();

            foreach (SingleImageData sourcePhotoData in sourcePhotoDataCollection)
            {
                CurrentView.AddNewItem(sourcePhotoData);
            }

            CurrentView.SetSpinnerActive(false);
        }

        public void SaveCurrentImageList ()
        {
            SaveUtils.SaveCurrentPhotos(new List<SingleImageData>(CurrentView.ContainingElementsCollection.Keys));
        }

        public void LoadImages ()
        {
            PopulateList(SaveUtils.LoadImages());
        }
    }
}
