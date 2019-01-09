using FootballAPI.DataLayer;
using FootballAPI.DataLayer.Models;
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

        // POST: api/Load/PlayerSeasonStats
        [Route("api/Load/Player/SeasonStats")]
        public string PostSeasonStats()
        {
            LoadPlayers lp = new LoadPlayers(new Season("2018", false));
            int effected = lp.loadSeasonStats();
            return effected + " Rows Added To Database";
        }
        // POST: api/Load/PlayerGameStats
        [Route("api/Load/Player/GameStats/{team}/{position}")]
        public Object PostGameStats(string team,string position)
        {
            LoadPlayers lp = new LoadPlayers(new Season("2018", false));
            Effected effected;
            try
            {
                effected = new Effected (lp.loadGameStats(team, position));
            }
            catch(Exception e)
            {
                return e;
            }
            return effected;
        }



    }
}
