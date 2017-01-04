using Prism.Commands;
using Prism.Mvvm;
using PrismTextToSpeech.Services;

namespace PrismTextToSpeech.ViewModels
{
    public class MainPageViewModel : BindableBase
    {
        private ITextToSpeech _textToSpeech;

        private string _speakText;
        public string SpeakText
        {
            get { return _speakText; }
            set
            {
                SetProperty(ref _speakText, value);
                SpeakCommand.RaiseCanExecuteChanged();
            }
        }

        public MainPageViewModel(ITextToSpeech textToSpeech)
        {
            _textToSpeech = textToSpeech;
        }

        public DelegateCommand SpeakCommand => new DelegateCommand(
            () =>
            {
                _textToSpeech.Speak(SpeakText);
            },
            () => !string.IsNullOrEmpty(SpeakText)).ObservesProperty(() => this.SpeakText);
    }
}
