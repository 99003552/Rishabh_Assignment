using Rishabh_Assignment.Views;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace Rishabh_Assignment.ViewModels
{
    public class SignUpViewModel : BaseViewModel
    {

        public ICommand GoBack { get; private set; }
        private string email = String.Empty, 
            password = String.Empty, 
            first = String.Empty, 
            last = String.Empty, 
            phone = String.Empty,
            confirm=String.Empty;
        private bool isChecked = false;
        public string FirstName
        {
            get => first;
            set
            {
                SetProperty(ref email, value);
                (SignUpCommand as Command).ChangeCanExecute();
            }
        }
        public string LastName
        {
            get => last;
            set
            {
                SetProperty(ref email, value);
                (SignUpCommand as Command).ChangeCanExecute();
            }
        }
    
        public string Email
        {
            get => email;
            set
            {
                SetProperty(ref email, value);
                (SignUpCommand as Command).ChangeCanExecute();
            }
        }

        public string Password
        {
            get => password;
            set
            {
                SetProperty(ref password, value);
                (SignUpCommand as Command).ChangeCanExecute();
            }
        }
        public string Confirm
        {
            get => confirm;
            set
            {
                SetProperty(ref email, value);
                (SignUpCommand as Command).ChangeCanExecute();
            }
        }
        public string Phone
        {
            get => phone;
            set
            {
                SetProperty(ref email, value);
                (SignUpCommand as Command).ChangeCanExecute();
            }
        }
        public bool IsChecked
        { 
            get => isChecked;
            set => SetProperty(ref isChecked, value);
        }
        public ICommand SignUpCommand { get; private set; }
        public SignUpViewModel()
        {
            SignUpCommand = new Command(
                execute: () => { SignUp(); },
                canExecute: () =>
                {
                    return Email.Contains("@") && Password.Length > 5 && IsChecked;
                });

            GoBack = new Command(() => App.Current.MainPage.Navigation.PushModalAsync(new Login()));
            
        }
        private void SignUp()
        {
            App.Current.MainPage.DisplayAlert("SignUp", "Clicked", "OK");
        }
    }
}

