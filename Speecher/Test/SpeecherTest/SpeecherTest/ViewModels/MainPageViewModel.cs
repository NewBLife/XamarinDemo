using Plugin.Speecher;
using Prism.Commands;
using Prism.Mvvm;

namespace SpeecherTest.ViewModels
{
    public class MainPageViewModel : BindableBase
    {
        private string _speakText;
        public string SpeakText
        {
            get { return _speakText; }
            set
            {
                SetProperty(ref _speakText, value);
            }
        }

        public MainPageViewModel()
        {
        }

        public DelegateCommand SpeakCommand => new DelegateCommand(
            () =>
            {
                CrossSpeecher.Current.Speak(SpeakText);
            },
            () => !string.IsNullOrEmpty(SpeakText)).ObservesProperty(() => this.SpeakText);
    }
}
