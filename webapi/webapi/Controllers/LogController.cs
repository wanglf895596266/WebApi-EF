using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using webapi.Models;
using webapi.Services;

namespace webapi.Controllers
{
    public class LogController : ApiController
    {
        private readonly ILogService _logService;

        public LogController(ILogService logService)
        {
            _logService = logService;
        }


        [System.Web.Http.HttpGet]
        public IEnumerable<LogModel> LogList()
        {
            var model = _logService.SearchLog().Select(t => new LogModel()
            {
                Id = t.id,
                Message = t.Message,
                LogLevelId = t.LogLevelId,
                LevelName = t.LogLevel.ToString(),
                CreateTime = t.CreateTime,
                UserName = t.User.name
            }).ToList();
            return model;
        }
    }
}