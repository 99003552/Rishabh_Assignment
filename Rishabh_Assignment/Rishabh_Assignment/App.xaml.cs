using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Rishabh_Assignment
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new Views.Profile();
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
