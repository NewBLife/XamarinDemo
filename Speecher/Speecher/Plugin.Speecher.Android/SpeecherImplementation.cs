using Android.App;
using Android.Runtime;
using Android.Speech.Tts;
using Plugin.Speecher.Abstractions;
using System.Collections.Generic;

namespace Plugin.Speecher
{
    /// <summary>
    /// Implementation for Feature
    /// </summary>
    public class SpeecherImplementation : Java.Lang.Object, ISpeecher, TextToSpeech.IOnInitListener
    {
        TextToSpeech speaker;
        string toSpeak;
        public SpeecherImplementation() { }

        public void Speak(string text)
        {
            var ctx = Application.Context;
            toSpeak = text;
            if (speaker == null)
            {
                speaker = new TextToSpeech(ctx, this);
            }
            else
            {
                var p = new Dictionary<string, string>();
                speaker.Speak(toSpeak, QueueMode.Flush, p);
            }
        }

        public void OnInit([GeneratedEnum] OperationResult status)
        {
            if (status.Equals(OperationResult.Success))
            {
                var p = new Dictionary<string, string>();
                speaker.Speak(toSpeak, QueueMode.Flush, p);
            }
            else
            {
                System.Diagnostics.Debug.WriteLine("was quiet");
            }
        }
    }
}