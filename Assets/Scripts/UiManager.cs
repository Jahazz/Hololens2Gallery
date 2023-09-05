using Gallery.GUI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Gallery.Singletons
{
    public class UiManager : MonoBehaviour
    {
        [field: SerializeField]
        public ImageListController ImageListControllerInstance { get; private set; }
        [field: SerializeField]
        public SearchMenuController SearchMenuControllerInstance { get; private set; }
    }
}
