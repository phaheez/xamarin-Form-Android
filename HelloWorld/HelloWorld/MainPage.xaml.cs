using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace HelloWorld
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            var assembly = typeof(MainPage);
            iconImage.Source = ImageSource.FromResource("HelloWorld.Assets.Images.paypal.png", assembly);
        }

        private void BtnLogin_Clicked(object sender, EventArgs e)
        {
            var isEmailEmpty = string.IsNullOrEmpty(txtEmail.Text);
            var isPasswordEmpty = string.IsNullOrEmpty(txtPassword.Text);

            if (isEmailEmpty || isPasswordEmpty)
            {

            }
            else
            {
                Navigation.PushAsync(new HomePage());
            }
        }

        private void BtnRegisterUser_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new RegisterPage());
        }
    }
}
