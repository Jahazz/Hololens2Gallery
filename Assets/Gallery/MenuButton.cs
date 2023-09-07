using Microsoft.MixedReality.Toolkit.UI;
using UnityEngine;

namespace Gallery.GUI
{
    public class MenuButton : MonoBehaviour
    {
        [field: SerializeField]
        private Spinner SpinnerInstance { get; set; }
        [field: SerializeField]
        private Interactable ButtonInteractibleInstance { get; set; }

        public void SetLoadingState (bool isLoading)
        {
            ButtonInteractibleInstance.IsEnabled = !isLoading;
            SpinnerInstance.gameObject.SetActive(isLoading);
        }
    }
}

