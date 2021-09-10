using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace APIDemo.Models
{
    
    public class UserLogin
    {
        public string UserName { get; set; }

        public string Password { get; set; }

        public int? UTID { get; set; }
    }
}