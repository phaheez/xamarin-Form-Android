using HelloWorld.Helpers;
using HelloWorld.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace HelloWorld.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class LoginPage : ContentPage
	{
        public readonly ApiServices services = new ApiServices();

        private bool IsConnected;

        public LoginPage ()
		{
			InitializeComponent ();

            Init();
        }

        private void Init()
        {
            var assembly = typeof(LoginPage);
            iconImage.Source = ImageSource.FromResource("HelloWorld.Assets.Images.paypal.png", assembly);

            BindingContext = this;
            IsBusy = false;

            IsConnected = Connectivity.CheckConnectivity();

            txtEmail.Focus();
            txtEmail.Completed += (s, e) => txtPassword.Focus();

            txtEmail.TextChanged += LoginTextWatcher_TextChanged;
            txtPassword.TextChanged += LoginTextWatcher_TextChanged;
        }

        //Enable login button if input text is not empty
        private void LoginTextWatcher_TextChanged(object sender, TextChangedEventArgs e)
        {
            var emailInput = txtEmail.Text.Trim();
            var pwordInput = txtPassword.Text.Trim();

            BtnLogin.IsEnabled = (!string.IsNullOrEmpty(emailInput) && !string.IsNullOrEmpty(pwordInput)) ? true : false;
        }

        private async void BtnSignUp_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new RegisterPage());
        }

        private async void BtnLogin_Clicked(object sender, EventArgs e)
        {
            if (IsConnected == false)
            {
                await DisplayAlert("Info", "Sorry, No Internet Connection", "Ok");
            }
            else
            {
                IsBusy = true;

                var result = await services.LoginAsync(txtEmail.Text, txtPassword.Text);

                //ShowOverlay(loader);

                IsBusy = false;

                if (result.Success == true && result.Results != null)
                {
                    await DisplayAlert("Login[Success]", "Login SUccessful", "Ok");
                }
                else if (result.ErrorMessage != null)
                {
                    await DisplayAlert("Login[Error]", result.ErrorMessage, "Ok");
                }
            }
        }

        public void ShowOverlay(ActivityIndicator loadingIndicator)
        {
            var overlay = new AbsoluteLayout();
            var content = new StackLayout();
            //var loadingIndicator = new ActivityIndicator();
            AbsoluteLayout.SetLayoutFlags(content, AbsoluteLayoutFlags.PositionProportional);
            AbsoluteLayout.SetLayoutBounds(content, new Rectangle(0f, 0f, AbsoluteLayout.AutoSize, AbsoluteLayout.AutoSize));
            AbsoluteLayout.SetLayoutFlags(loadingIndicator, AbsoluteLayoutFlags.PositionProportional);
            AbsoluteLayout.SetLayoutBounds(loadingIndicator, new Rectangle(0.5, 0.5, AbsoluteLayout.AutoSize, AbsoluteLayout.AutoSize));
            overlay.Children.Add(content);
            overlay.Children.Add(loadingIndicator);
        }
    }
}