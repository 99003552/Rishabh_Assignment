
using Rishabh_Assignment.DataServices;
using Rishabh_Assignment.Helper;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;
using Rishabh_Assignment.Comman;
using Rishabh_Assignment.Views;

namespace Rishabh_Assignment.ViewModels
{
    class LoginViewModel : BaseViewModel
    {
        private string email = String.Empty, password = String.Empty ;
        private bool isChecked = false;

        public string Email
        {
            get => email;
            set
            {
                SetProperty(ref email, value);
                (LoginCommand as Command).ChangeCanExecute();
            }
        }

        public string Password
        {
            get => password;
            set
            {
                SetProperty(ref password, value);
                (LoginCommand as Command).ChangeCanExecute();
            }
        }

        public bool IsChecked { get => isChecked; set => SetProperty(ref isChecked, value); }
        public ICommand LoginCommand { get; private set; }
        public ICommand RegisterCommand { get; private set; }
        public LoginViewModel()
        {
            LoginCommand = new Command(
                execute: () => { Login(); },
                canExecute: () =>
                {
                    //return Email.Contains("@") && Password.Length > 5 && IsChecked;
                    return Validator.IsVaildEmail(Email) && Password.Length > 3;
                });
            RegisterCommand = new Command(() => App.Current.MainPage.Navigation.PushModalAsync(new Register()));
        }
        public class UserPayLoad
        {
            public string email;
            public string password;
            public UserPayLoad(string email,string password)
            {
                this.email = email;
                this.password = password;
            }
        }
        private async void Login()
        {
           if(!Network.IsNetWorkAvailable())
            {
                await App.Current.MainPage.DisplayAlert("Error", Comman.AppConstatnts.UserMessages.NetworkErrorMessage, "OK");
                //Shw an error msg
                return;
            }
           try
            {
                IsBusy = true;
                UserPayLoad payLoad = new UserPayLoad(Email, Password);
                LoginResponce reponse = await RishabhDataService.Instance.LoginUser(payLoad);
                IsBusy = false;
                Console.WriteLine(reponse.token);
                Session.UpdateSession(AppConstatnts.SessionConstants.Token,reponse.token);

                Session.UpdateSession(AppConstatnts.SessionConstants.Email,Email);
                App.Current.MainPage = new NavigationPage(new Views.HomeView());
            }
            catch(Exception ex)
            {
                IsBusy = false;
            }
        }
    }
}
