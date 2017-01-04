using Android.Runtime;
using Android.Speech.Tts;
using System.Collections.Generic;
using TextToSpeechDemo.Droid;
using Xamarin.Forms;

[assembly: Dependency(typeof(TextToSpeech_Android))]
namespace TextToSpeechDemo.Droid
{
    public class TextToSpeech_Android : Java.Lang.Object, ITextToSpeech, TextToSpeech.IOnInitListener
    {
        TextToSpeech speaker;
        string toSpeak;
        public TextToSpeech_Android() { }

        public void Speak(string text)
        {
            var ctx = Forms.Context;
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

                System.Diagnostics.Debug.WriteLine("speaker init");

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