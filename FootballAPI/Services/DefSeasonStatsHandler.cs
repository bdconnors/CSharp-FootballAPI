using FootballAPI.Models;
using FootballAPI.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FootballAPI.Services
{
    public class DefSeasonStatsHandler : IDataAccessLayer<DefenseSeasonStats>
    {
        public static Database db = new Database();
        public DefenseSeasonStats obj { get; set; }

        public DefSeasonStatsHandler(DefenseSeasonStats seasonStats)
        {
            obj = seasonStats;
        }
        public DefSeasonStatsHandler()
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