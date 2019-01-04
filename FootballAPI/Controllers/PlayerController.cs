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
    [Route("api/Player")]
    public class PlayerController : ApiController
    {
        //GET: api/Player/playerid
        [Route("api/Player/{playerid}")]
        public PlayerSeasonLog Get(string playerid)
        {
            PlayerSeasonLog log = new PlayerSeasonLog(new Player(playerid));
            PlayerSeasonLogAccess logAccess = new PlayerSeasonLogAccess(log);
            logAccess.Fetch();
            return log;
        }
        // GET: api/Player/5/5
        [Route("api/Player/{playerid}/{gameid}")]
        public PlayerGameLog Get(string playerid,string gameid)
        {
            PlayerGameLog log = new PlayerGameLog(new Player(playerid),new Game(gameid));
            PlayerGameLogAccess logAccess = new PlayerGameLogAccess(log);
            logAccess.Fetch();
            return log;
        }

    }
}
