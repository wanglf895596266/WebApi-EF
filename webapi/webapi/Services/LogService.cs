using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using webapi.DAL;

namespace webapi.Services
{
    public class LogService:ILogService
    {
        private AccountContext _context;

        public LogService(AccountContext context)
        {
            _context = context;
        }

        public override List<Log> SearchLog()
        {
            return _context.LogList.ToList();
        }
    }
}