using HelloWorld.Helpers;
using HelloWorld.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace HelloWorld
{
    public partial class App : Application
    {
        public static string DatabasePath = string.Empty;
        public App(string databasePath)
        {
            InitializeComponent();

            SetMainPage();

            //MainPage = new Views.RegisterPage();

            //MainPage = new NavigationPage(new MainPage())
            //{
            //    BarBackgroundColor = Color.DodgerBlue,
            //    BarTextColor = Color.White
            //};

            DatabasePath = databasePath;
        }

        public App()
        {
            InitializeComponent();
        }

        private void SetMainPage()
        {
            MainPage = !string.IsNullOrEmpty(Settings.AccessToken) ? new NavigationPage(new MainPage()) : new NavigationPage(new LoginPage());
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
