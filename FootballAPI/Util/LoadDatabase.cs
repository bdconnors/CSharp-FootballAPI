using FootballAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FootballAPI.Util
{
    public class LoadDatabase
    {
        private static Database db = new Database();
        public Season season { get; set; }
        public LoadDatabase(Season season)
        {
            this.season = season;
        }
        public int LoadTeams()
        {        

            TeamRequest request = new TeamRequest(season);
            MultipleTeamHandler handler = new MultipleTeamHandler(request.GetTeams());
            db.StartTransaction();
            int effected = handler.Post();
            db.EndTransaction();
            return effected;
        }
        public int LoadPlayers()
        {

            PlayerRequest request = new PlayerRequest(season);
            MultiplePlayerHandler handler = new MultiplePlayerHandler(request.GetPlayers());
            db.StartTransaction();
            int effected = handler.Post();
            db.EndTransaction();
            return effected;
        }
        public int LoadGames()
        {

            GameRequest request = new GameRequest(season);
            MultipleGameHandler handler = new MultipleGameHandler(request.GetGames());
            db.StartTransaction();
            
            int effected = handler.Post();
            db.EndTransaction();
            return effected;
        }

    }
}