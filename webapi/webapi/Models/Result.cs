using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace webapi.Models
{
    public class Result<T>
    {
        public string Flag { get; set; }

        public string Error { get; set; }

        public T Data { get; set; }
    }
}