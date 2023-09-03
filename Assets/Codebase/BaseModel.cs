using UnityEngine;

namespace Codebase.MVC
{
    public class BaseModel<ViewType> : MonoBehaviour where ViewType : BaseView
    {
        public ViewType CurrentView { get; private set; }

        public virtual void Initialize (ViewType currentView)
        {
            CurrentView = currentView;
        }
    }
}
