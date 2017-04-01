using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace webapi.DAL
{
    public class Log:Entity<int>
    {
        public string Message { get; set; }

        public int LogLevelId { get; set; }

        public DateTime CreateTime { get; set; }

        public int? UserId { get; set; }

        public LogLevel LogLevel
        {
            get { return (LogLevel) this.LogLevelId; }
            set { this.LogLevelId = (int) value; }
        }

        public virtual User User { get; set; }
    }

    public enum LogLevel
    {
        Debug=10,
        Information=20,
        Warning=30,
        Error=40,
        Fatal=50
    }
}