using FootballAPI.Models;
using FootballAPI.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace FootballAPI.Controllers
{
    [Route("api/LoadDatabase")]
    public class LoadDatabaseController : ApiController
    {


        // POST: api/LoadDatabase/{season}/{type}/Teams
        [Route("api/LoadDatabase/{season}/{type}/Teams")]
        public string PostTeams(string season,string type)
        {
            bool playoffs = false;
            if(type.Equals("regular", StringComparison.InvariantCultureIgnoreCase))
            {
                playoffs = false;
            }
            else if(type.Equals("playoffs", StringComparison.InvariantCultureIgnoreCase))
            {
                playoffs = true;
            }
            LoadDatabase ldb = new LoadDatabase(new Season(season,playoffs));
            int effected = ldb.LoadTeams();
            return effected + " new Team records added to the database!";
        }
        // POST: api/LoadDatabase/{season}/{type}/Teams
        [Route("api/LoadDatabase/{season}/{type}/Players")]
        public string PostPlayers(string season, string type)
        {
            bool playoffs = false;
            if (type.Equals("regular", StringComparison.InvariantCultureIgnoreCase))
            {
                playoffs = false;
            }
            else if (type.Equals("playoffs", StringComparison.InvariantCultureIgnoreCase))
            {
                playoffs = true;
            }
            LoadDatabase ldb = new LoadDatabase(new Season(season, playoffs));
            int effected = ldb.LoadPlayers();
            return effected + " new Player records added to the database!";
        }
        // POST: api/LoadDatabase/{season}/{type}/Games
        [Route("api/LoadDatabase/{season}/{type}/Games")]
        public string PostGames(string season, string type)
        {
            bool playoffs = false;
            if (type.Equals("regular", StringComparison.InvariantCultureIgnoreCase))
            {
                playoffs = false;
            }
            else if (type.Equals("playoffs", StringComparison.InvariantCultureIgnoreCase))
            {
                playoffs = true;
            }
            LoadDatabase ldb = new LoadDatabase(new Season(season, playoffs));
            int effected = ldb.LoadGames();
            return effected + " new Game records added to the database!";
        }


    }
}
