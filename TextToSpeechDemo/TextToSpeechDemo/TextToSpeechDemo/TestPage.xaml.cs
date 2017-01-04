
using System;
using Xamarin.Forms;

namespace TextToSpeechDemo
{
    public partial class TestPage : ContentPage
    {
        public TestPage()
        {
            InitializeComponent();
        }
        public void btnSpeak_Clicked(object sender, EventArgs args)
        {
            DependencyService.Get<ITextToSpeech>().Speak(txtData.Text.Trim());
        }
    }
}
