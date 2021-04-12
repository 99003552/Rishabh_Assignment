
using Rishabh_Assignment.Comman;
using Rishabh_Assignment.DataServices;
using Rishabh_Assignment.Helper;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace Rishabh_Assignment.ViewModels
{
    public class HomeViewModel : BaseViewModel
    {
        private List<User> users;
        public List<User> Users
        {
            get => users;
            set => SetProperty(ref users, value);
        }
        public ICommand ItemTappedCommand { get; private set; }
        public HomeViewModel()
        {
            GetUsers();
            ItemTappedCommand = new Command<User>(SelectedItem);
        }

        private void SelectedItem(User user)
        {

        }

        private async void GetUsers()
        {
            if (!Network.IsNetWorkAvailable())
            {
                await App.Current.MainPage.DisplayAlert("Error", Comman.AppConstatnts.UserMessages.NetworkErrorMessage, "OK");
                return;
            }
            try
            {
                IsBusy = true;
                Dictionary<string, object> dict = new Dictionary<string, object>();
                dict.Add("page", "2");
                var result = await RishabhDataService.Instance.GetUsers(dict);
                IsBusy = false;
                if (result != null)
                {
                    Users = result.data;
                }
            }
            catch (Exception ex)
            {
                IsBusy = false;
            }
        }
    }
}