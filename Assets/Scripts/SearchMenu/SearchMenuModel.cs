using Codebase.MVC;
using Gallery.FlickrAPIIntegration;
using UnityEngine;

namespace Gallery.GUI
{
    public class SearchMenuModel : BaseModel<SearchMenuView>
    {
        [field: SerializeField]
        private int DefaultElementCount { get; set; }
        [field: SerializeField]
        private string DefaultSearchText { get; set; }

        private int ElementCount { get; set; }
        private string SearchText { get; set; }

        public void SetElementCount (float percentageOfMax)
        {
            float preParseElementCount = (SoapConfig.MAX_ELEMENT_COUNT * percentageOfMax);
            ElementCount = (int)preParseElementCount;
            CurrentView.SetElementCountLabel(ElementCount);
        }

        public override void Initialize (SearchMenuView currentView)
        {
            base.Initialize(currentView);

            ElementCount = DefaultElementCount;
            SearchText = DefaultSearchText;

            CurrentView.SetElementCountLabel(ElementCount);
            CurrentView.SetSliderValue((float)ElementCount / SoapConfig.MAX_ELEMENT_COUNT);
            CurrentView.SetSearchText(DefaultSearchText);
        }

        public void ShowKeyboard ()
        {
            CurrentView.ShowKeyboard(SearchText);
        }

        public void SetSearchText (string searchText)
        {
            SearchText = searchText;
            CurrentView.SetSearchText(searchText);
        }
    }
}
