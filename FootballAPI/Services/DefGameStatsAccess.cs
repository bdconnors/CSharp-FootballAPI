using FootballAPI.Models;
using FootballAPI.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FootballAPI.Services
{
    public class DefGameStatsAccess : IDataAccessLayer<DefenseGameStats>
    {
        public static Database db = new Database();
        public DefenseGameStats obj { get; set; }

        public DefGameStatsAccess(DefenseGameStats gameStats)
        {
            obj = gameStats;
        }
        public DefGameStatsAccess()
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