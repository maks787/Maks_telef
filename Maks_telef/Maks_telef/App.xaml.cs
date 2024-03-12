using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Maks_telef
{
    public partial class App : Application
    {
        public App()
        {
           

            MainPage = new NavigationPage(new StartPage1());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
