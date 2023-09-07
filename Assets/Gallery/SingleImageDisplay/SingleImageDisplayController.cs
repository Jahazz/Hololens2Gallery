using Codebase.MVC;
using Gallery.Data;

namespace Gallery.GUI
{
    public class SingleImageDisplayController : BaseController<SingleImageDisplayModel, SingleImageDisplayView>
    {
        public void Initialize (SinglePhotoData imageData)
        {
            CurrentModel.Initialize(imageData);
        }
    }
}
