using Microsoft.Practices.Unity;
using Prism.Unity;
using PrismTextToSpeech.Services;

namespace PrismTextToSpeech.UWP
{
    public sealed partial class MainPage
    {
        public MainPage()
        {
            this.InitializeComponent();

            LoadApplication(new PrismTextToSpeech.App(new UwpInitializer()));
        }
    }

    public class UwpInitializer : IPlatformInitializer
    {
        public void RegisterTypes(IUnityContainer container)
        {
            container.RegisterType<ITextToSpeech, TextToSpeech_UWP>();
        }
    }

}
