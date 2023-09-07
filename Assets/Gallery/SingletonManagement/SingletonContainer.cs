using Codebase;
using Gallery.FlickrAPIIntegration.Mediator;
using Gallery.GUI;
using UnityEngine;

namespace Gallery.Singletons
{
    public class SingletonContainer : SingletonMonobehaviour<SingletonContainer>
    {
        [field: SerializeField]
        public NetworkingMediator NetworkingMediatorInstance { get; private set; }
        [field: SerializeField]
        public UiManager UiManagerInstance { get; private set; }
        [field: SerializeField]
        public DialogManager DialogManagerInstance { get; private set; }
    }
}

