﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Rishabh_Assignment.DataServices
{
    public class ProfileResponce
    {
        public User data { get; set; }
        public Support support { get; set; }

    }
    public class Support
    {
        public string url { get; set; }
        public string text { get; set; }
    }
}
