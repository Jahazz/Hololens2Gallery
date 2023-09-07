using Codebase.MVC.List;
using Gallery.Data;
using System.Collections.Generic;

namespace Gallery.GUI
{
    public class ImageListController : ListController<ImageListElement, SinglePhotoData, ImageListView, ImageListModel>
    {
        public void StartSearchForImages (string textToSearch, int maxImagecount)
        {
            CurrentModel.GetImageList(textToSearch, maxImagecount);
        }

        public void SetupCollection (List<SinglePhotoData> sourcePhotoDataCollection)
        {
            CurrentModel.PopulateList(sourcePhotoDataCollection);
        }

        public List<SinglePhotoData> GetCurrentPhotoCollection ()
        {
            return CurrentModel.GetCurrentPhotoCollection();
        }
    }
}
