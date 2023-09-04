
using Codebase.MVC;
using Microsoft.MixedReality.Toolkit.UI;
using UnityEngine;

namespace Gallery.GUI
{
    public class SearchMenuController : BaseController<SearchMenuModel, SearchMenuView>
    {
        public void HandleSliderValueChanged (SliderEventData sliderData)
        {
            CurrentModel.SetElementCount(sliderData.NewValue);
        }

        public void ShowKeyboard ()
        {
            CurrentModel.ShowKeyboard();
        }

        public void HandleOnKeyboardCommit (string text)
        {
            CurrentModel.SetSearchText(text);
        }
    }
}
