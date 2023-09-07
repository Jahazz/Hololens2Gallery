using Codebase.MVC;
using Gallery.Data;

namespace Gallery.GUI
{
    public class SingleImageDisplayController : BaseController<SingleImageDisplayModel, SingleImageDisplayView>
    {
        public void Initialize (SingleImageData imageData)
        {
            CurrentModel.Initialize(imageData);
        }
    }
}
