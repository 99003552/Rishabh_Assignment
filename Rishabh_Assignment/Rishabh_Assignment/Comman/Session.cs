using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Essentials;

namespace Rishabh_Assignment.Comman
{
    public  static class Session
    {
        public static void UpdateSession(string key,string value)
        {
            Preferences.Set(key, value);
        }
        public static string Get(string key)
        {
            if(Preferences.ContainsKey(key))
            {
                return Preferences.Get(key, null);
            }
            return null;
        }
        public static void LogOut()
        {
            Preferences.Clear();
        }
    }
}
