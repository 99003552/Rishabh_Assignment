using Rishabh_Assignment.DataServices;
using Rishabh_Assignment.Helper;
using Rishabh_Assignment.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Rishabh_Assignment.ModelViews
{
    public class ProfileViewModel: BaseViewModel
    {
        private List<User> users;
        public string Email
        {
            get => email;
            set => SetProperty(ref email, value);
        }
        public string Name
        {
            get => name;
            set => SetProperty(ref name, value);
        }
        public string Avatar
        {
            get => avatar;
            set => SetProperty(ref avatar, value);
        }
        public string SupportUrl
        {
            get => supportUrl;
            set => SetProperty(ref supportUrl, value);
        }
        public string SupportText
        {
            get => supportText;
            set => SetProperty(ref supportText, value);
        }
        private string email,name,avatar,supportUrl,supportText;
        public ICommand GetProfileCommand { get;private set; }
        public ProfileViewModel()
        {
            getProfile();
        }

        private async void getProfile()
        {
            if (!Network.IsNetWorkAvailable())
            {
                return;
            }
            try
            {
                IsBusy = true;
              
                var result = await RishabhDataService.Instance.GetProfile(null);
                IsBusy = false;
                if (result != null)
                {
                    Email = result.data.email;
                    Name = result.data.first_name+" "+ result.data.last_name;
                    Avatar = result.data.avatar;
                    SupportUrl = result.support.url;
                    SupportText = result.support.text;
                }
            }
            catch (Exception ex)
            {
                IsBusy = false;
            }
        }

       
    }
}
