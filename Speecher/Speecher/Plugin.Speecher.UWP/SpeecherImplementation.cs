using Plugin.Speecher.Abstractions;
using System;
using Windows.Media.SpeechSynthesis;
using Windows.UI.Xaml.Controls;

namespace Plugin.Speecher
{
    /// <summary>
    /// Implementation for Feature
    /// </summary>
    public class SpeecherImplementation : ISpeecher
    {
        public async void Speak(string text)
        {
            MediaElement mediaElement = new MediaElement();

            var synth = new SpeechSynthesizer();
            var stream = await synth.SynthesizeTextToStreamAsync(text);
            mediaElement.SetSource(stream, stream.ContentType);
            mediaElement.Play();
        }
    }
}