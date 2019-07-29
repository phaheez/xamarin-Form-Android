using HelloWorld.Helpers;
using HelloWorld.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace HelloWorld.ViewModels
{
    public class RegisterViewModel
    {
        ApiServices _apiServices = new ApiServices();

        public string UserName { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public string PhoneNumber { get; set; }

        public string Message { get; set; }

        public ICommand RegisterCommand
        {
            get
            {
                return new Command(async() =>
                {
                    var isSuccess = await _apiServices.RegisterAsync(UserName, FullName, Email, Password, ConfirmPassword, PhoneNumber);

                    Settings.UserName = UserName;
                    Settings.Password = Password;

                    Message = isSuccess ? "Registered Successfully" : "Retry Later";
                });
            }
        }
    }
}
