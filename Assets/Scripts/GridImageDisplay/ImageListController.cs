using Codebase.MVC.List;

namespace Gallery.GUI
{
    public class ImageListController : ListController<ImageListElement, ImageListElementData, ImageListView, ImageListModel>
    {
        public void StartSearchForImages (string textToSearch, int maxImagecount)
        {
            CurrentModel.GetImageList(textToSearch, maxImagecount);
        }
    }
}
