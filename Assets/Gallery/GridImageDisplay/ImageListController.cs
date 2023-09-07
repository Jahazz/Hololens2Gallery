using Codebase.MVC.List;
using Gallery.Data;

namespace Gallery.GUI
{
    public class ImageListController : ListController<ImageListElement, SinglePhotoData, ImageListView, ImageListModel>
    {
        public void StartSearchForImages (string textToSearch, int maxImagecount)
        {
            CurrentModel.GetImageList(textToSearch, maxImagecount);
        }

        public void LoadImages ()
        {
            CurrentModel.LoadImages();
        }

        public void SaveList ()
        {
            CurrentModel.SaveCurrentImageList();
        }
    }
}
