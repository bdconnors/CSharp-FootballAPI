using FootballAPI.Models;
using FootballAPI.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace FootballAPI.Controllers
{
    public class PlayerController : ApiController
    {
  
        // GET: api/Player/5
        public PlayerSeasonLog Get(string id)
        {
            PlayerSeasonLog log = new PlayerSeasonLog(id);
            PlayerSeasonLogAccess logAccess = new PlayerSeasonLogAccess(log);
            logAccess.Fetch();
            return log;
        }

    }
}
