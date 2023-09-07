using Codebase.MVC.List;
using Gallery.FlickrAPIIntegration.Endpoints;
using Gallery.Saving;
using Gallery.Singletons;
using System.Collections.Generic;
using Gallery.Data;

namespace Gallery.GUI
{
    public class ImageListModel : ListModel<ImageListElement, SinglePhotoData, ImageListView>
    {
        public void GetImageList (string textToSearch, int maxImagecount)
        {
            CurrentView.SetSpinnerActive(true);
            SingletonContainer.Instance.NetworkingMediatorInstance.SearchForPhotosByName(textToSearch, maxImagecount, PopulateList);
        }

        public void PopulateList (List<Photo> sourcePhotoDataCollection)
        {
            List<SinglePhotoData> singleImagesCollection = new List<SinglePhotoData>();

            foreach (Photo sourcePhotoData in sourcePhotoDataCollection)
            {
                singleImagesCollection.Add(new SinglePhotoData(sourcePhotoData));
            }

            PopulateList(singleImagesCollection);
        }

        public void PopulateList (List<SinglePhotoData> sourcePhotoDataCollection)
        {
            CurrentView.ClearList();

            foreach (SinglePhotoData sourcePhotoData in sourcePhotoDataCollection)
            {
                CurrentView.AddNewItem(sourcePhotoData);
            }

            CurrentView.SetSpinnerActive(false);
        }

        public List<SinglePhotoData> GetCurrentPhotoCollection ()
        {
            return new List<SinglePhotoData>(CurrentView.ContainingElementsCollection.Keys);
        }
    }
}
