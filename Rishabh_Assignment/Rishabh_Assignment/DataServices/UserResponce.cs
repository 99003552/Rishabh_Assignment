using System;
using System.Collections.Generic;
using System.Text;

namespace Rishabh_Assignment.DataServices
{
    public class UserResponce
    {
        public List<User> data { get; set; }

    }
    public class User
    {
        public int id { get; set; }
        public string email { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }

        public string avatar { get; set; }
    }
}
