using System;
using System.Collections.Generic;
using System.Text;

namespace Rishabh_Assignment.Comman
{
    public static class AppConstatnts
    {
        public static class WebConstants
        {
            public static readonly string BaseURL = "https://reqres.in/api/";
            public static readonly string Login = "login";
            public static readonly string Users = "users";
            public static readonly string Profile = "users/2";
        }
        public static class UserMessages
        {
            public static readonly string NetworkErrorMessage = "Please Check the Internet Connection and Try Again....";
        }
        public static class SessionConstants

        {
            public static readonly string Token = "TOKEN";
            public static readonly string Email = "EMAIL";
        }
    }
}
