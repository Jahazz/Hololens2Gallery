using Codebase;
using Gallery.FlickrAPIIntegration.Mediator;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Gallery.Singletons
{
    public class SingletonContainer : SingletonMonobehaviour<SingletonContainer>
    {
        [field: SerializeField]
        public NetworkingMediator NetworkingMediatorInstance { get; private set; }
        [field: SerializeField]
        public UiManager UiManagerInstance { get; private set; }
    }
}

