using HelloWorld.Helpers;
using HelloWorld.Services;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace HelloWorld.ViewModels
{
    public class LoginViewModel
    {
        private ApiServices _apiServices = new ApiServices();
        public string UserName { get; set; }
        public string Password { get; set; }

        public ICommand LoginCommand
        {
            get
            {
                return new Command(async () =>
                {
                    var access_token  = await _apiServices.LoginAsync(UserName, Password);

                    //Settings.AccessToken = access_token;

                    Debug.WriteLine(Settings.AccessToken);
                    
                });
            }
        }

        public LoginViewModel() 
        {
            UserName = Settings.UserName;
            Password = Settings.Password;
        }
    }
}
