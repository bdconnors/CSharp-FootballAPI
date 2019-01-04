using FootballAPI.Models;
using FootballAPI.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FootballAPI.Services
{
    public class PlayerGameStatsAccess : IDataAccessLayer<PlayerGameStats>
    {
        public static Database db = new Database();
        public PlayerGameStats obj { get; set; }

        public PlayerGameStatsAccess(PlayerGameStats gameStats)
        {
            obj = gameStats;
        }
        public PlayerGameStatsAccess()
        {

        }
        public void Fetch()
        {

        }
        public int Post()
        {
            return 0;
        }
        public int Put()
        {
            return 0;
        }
        public int Delete()
        {
            return 0;
        }
    }
}