using FootballAPI.DataLayer.Models;
using FootballAPI.DataLayer.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace FootballAPI.Controllers
{
    [Route("api/Defense")]
    public class DefenseController : ApiController
    {

        // GET: api/Defense/SeasonStats/{team}
        [Route("api/Defense/SeasonStats/{team}")]
        public Object GetSeasonStats(string team)
        {
            Defense defense = new Defense(new Team(team));
            DefenseService service = new DefenseService(defense);
            try
            {
                service.GetSeasonLog();
            }
            catch(Exception e)
            {
                return e;
            }
            return defense;
        }
        // GET: api/Defense/GameStats/{team}/{gameid}
        [Route("api/Defense/GameStats/{team}/{gameid}")]
        public Object GetGameStats(string team,string gameid)
        {
            Defense defense = new Defense(new Team(team));
            DefenseService service = new DefenseService(defense);
            try
            {
                service.GetGame(gameid);
            }
            catch (Exception e)
            {
                return e;
            }
            return defense;
        }
        // GET: api/Defense/GameStats/{team}/{gameid}
        [Route("api/Defense/GameLogs/{team}")]
        public Object GetGameLogs(string team)
        {
            Defense defense = new Defense(new Team(team));
            DefenseService service = new DefenseService(defense);
            try
            {
                service.GetGameLogs();
            }
            catch (Exception e)
            {
                return e;
            }
            return defense;
        }



    }
}
