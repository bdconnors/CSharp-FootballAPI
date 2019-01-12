using FootballAPI.DataLayer;
using FootballAPI.DataLayer.Models;
using FootballAPI.DataLayer.Services;
using FootballAPI.DataLayer.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace FootballAPI.Controllers
{
    [Route("api/Load")]
    public class LoadController : ApiController
    {

        // POST: api/Load/Defense/SeasonStats
        [Route("api/Load/Defense/SeasonStats")]
        public Object Post()
        {
            Effected returnObj;
            try
            {
                int effected = 0;
                DefenseRequest request = new DefenseRequest(new Season("2018", false));
                DefenseService service = new DefenseService();
                List<Defense> defenses = request.GetSeasonStats();
                foreach (Defense defense in defenses)
                {
                    service.defense = defense;
                    effected += service.InsertSeasonLog();
                }
                returnObj = new Effected(effected);
                return returnObj;
            }
            catch (Exception e)
            {
                return e;
            }
        }
        // POST: api/Load/Defense/SeasonStats
        [Route("api/Load/Defense/GameStats")]
        public Object PostGameStats()
        {
            Effected returnObj;
            try
            {
                int effected = 0;
                DefenseRequest request = new DefenseRequest(new Season("2018", false));
                DefenseService service = new DefenseService();
                List<Defense> defenses = request.GetGameStats();
                foreach (Defense defense in defenses)
                {
                    service.defense = defense;
                    effected += service.InsertGameLogs();
                }
                returnObj = new Effected(effected);
                return returnObj;
            }
            catch (Exception e)
            {
                return e;
            }
        }




    }
}
