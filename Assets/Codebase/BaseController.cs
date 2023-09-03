using UnityEngine;

namespace Codebase.MVC
{
    public class BaseController<ModelType, ViewType> : MonoBehaviour where ModelType : BaseModel<ViewType> where ViewType : BaseView
    {
        [field: SerializeField]
        public ModelType CurrentModel { get; private set; }

        [field: SerializeField]
        public ViewType CurrentView { get; private set; }

        protected virtual void Awake ()
        {
            CurrentModel.Initialize(CurrentView);
        }
    }
}
