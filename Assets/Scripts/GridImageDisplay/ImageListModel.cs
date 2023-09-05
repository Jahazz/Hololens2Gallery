using Codebase.MVC.List;
using Gallery.FlickrAPIIntegration.Endpoints;
using Gallery.Singletons;
using System.Collections.Generic;

namespace Gallery.GUI
{
    public class ImageListModel : ListModel<ImageListElement, ImageListElementData, ImageListView>
    {
        public void GetImageList (string textToSearch, int maxImagecount)
        {
            CurrentView.SetSpinnerActive(true);
            SingletonContainer.Instance.NetworkingMediatorInstance.SearchForPhotosByName(textToSearch, maxImagecount, PopulateList);
        }

        public void PopulateList (List<Photo> sourcePhotoDataCollection)
        {
            CurrentView.ClearList();

            foreach (var sourcePhotoData in sourcePhotoDataCollection)
            {
                CurrentView.AddNewItem(new ImageListElementData(sourcePhotoData));
            }

            CurrentView.SetSpinnerActive(false);
            CurrentView.UpdateCollectionVisuals();
        }
    }
}
