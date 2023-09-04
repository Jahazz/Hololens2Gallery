using Codebase.MVC;
using Microsoft.MixedReality.Toolkit.UI;
using TMPro;
using UnityEngine;

namespace Gallery.GUI
{
    public class SearchMenuView : BaseView
    {
        [field: SerializeField]
        private TMP_Text ElementCountLabel { get; set; }
        [field: SerializeField]
        private TMP_Text SearchQuery { get; set; }
        [field: SerializeField]
        private PinchSlider ElementCountSlider { get; set; }
        [field: SerializeField]
        private Keyboard VirtualKeyboard { get; set; }

        [field: Space]
        [field: SerializeField]
        private string CountLabelFormat { get; set; }
        [field: SerializeField]
        private string SearchQueryFormat { get; set; }

        public void SetElementCountLabel (int count)
        {
            ElementCountLabel.text = string.Format(CountLabelFormat, count);
        }

        public void SetSliderValue (float value)
        {
            ElementCountSlider.SliderValue = value;
        }

        public void ShowKeyboard (string initialText)
        {
            VirtualKeyboard.ShowKeyboard(initialText);
        }

        public void SetSearchText (string text)
        {
            SearchQuery.text = string.Format(SearchQueryFormat, text);
        }
    }
}
