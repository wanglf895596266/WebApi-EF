using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using webapi.DAL;

namespace webapi.Services
{
    public abstract class ILogService
    {
        public abstract List<Log> SearchLog();
    }
}