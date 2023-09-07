using Gallery.Saving;
using Microsoft.MixedReality.Toolkit.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Gallery.GUI
{
    public class DialogManager : MonoBehaviour
    {
        [field: SerializeField]
        private string SaveSuccessLabel { get; set; }
        [field: SerializeField]
        private string SaveUnknownLabel { get; set; }
        [field: SerializeField]
        private string SaveEmptyGalleryLabel { get; set; }
        [field: SerializeField]
        private string SaveTitle { get; set; }

        [field: Space]
        [field: SerializeField]
        private string LoadSuccessLabel { get; set; }
        [field: SerializeField]
        private string LoadUnknownLabel { get; set; }
        [field: SerializeField]
        private string LoadNoFileLabel { get; set; }
        [field: SerializeField]
        private string LoadTitle { get; set; }

        [field: Space]
        [field: SerializeField]
        private GameObject DialogPrefab { get; set; }

        public void ShowDialog (LoadOutputType dialogType)
        {
            string title = LoadTitle;
            string message = string.Empty;

            switch (dialogType)
            {
                case LoadOutputType.OK:
                    message = LoadSuccessLabel;
                    break;
                case LoadOutputType.UNKNOWN_ERROR:
                    message = LoadUnknownLabel;
                    break;
                case LoadOutputType.NO_SAVE:
                    message = LoadNoFileLabel;
                    break;
                default:
                    break;
            }

            ShowDialog(title, message);
        }

        public void ShowDialog (SaveOutputType dialogType)
        {
            string title = SaveTitle;
            string message = string.Empty;

            switch (dialogType)
            {
                case SaveOutputType.OK:
                    message = SaveSuccessLabel;
                    break;
                case SaveOutputType.UNKNOWN_ERROR:
                    message = SaveUnknownLabel;
                    break;
                case SaveOutputType.EMPTY_GALLERY:
                    message = SaveEmptyGalleryLabel;
                    break;
                default:
                    break;
            }

            ShowDialog(title, message);
        }

        public void ShowDialog (string title, string message)
        {
            Dialog.Open(DialogPrefab, DialogButtonType.OK, title, message, true);
        }
    }
}
