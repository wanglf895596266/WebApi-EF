using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace webapi.Models
{
    public class LogModel
    {
        public int Id { get; set; }

        public string Message { get; set; }

        public int LogLevelId { get; set; }

        public string LevelName { get; set; }

        public DateTime CreateTime { get; set; }

        public string UserName { get; set; }
    }
}