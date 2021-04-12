using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Essentials;


namespace Rishabh_Assignment.Helper
{
    public static class Network
    {
        public static bool IsNetWorkAvailable()
        {
            if (Connectivity.NetworkAccess == NetworkAccess.ConstrainedInternet ||
                Connectivity.NetworkAccess == NetworkAccess.None ||
                Connectivity.NetworkAccess == NetworkAccess.Unknown           )
                return false;
            if (             Connectivity.NetworkAccess == NetworkAccess.Internet               )
                return true;
            return false;
        }
    }
}
