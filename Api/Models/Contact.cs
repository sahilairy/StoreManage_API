﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Api.Models
{
    public class Contact
    {
        public String Name { get; set; }
        public String Email { get; set; }
        public String Subject { get; set; }
        public String Message { get; set; }
    }
}