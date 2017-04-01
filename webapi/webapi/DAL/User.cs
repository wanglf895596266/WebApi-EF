using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace webapi.DAL
{
    public class User:Entity<int>
    {
        public string name { get; set; }

        public string age { get; set; }
    }
}