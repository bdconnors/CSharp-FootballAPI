using FootballAPI.Models;
using FootballAPI.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FootballAPI.Util
{
    public class MultipleDssHandler : IDataAccessLayer<List<DefenseSeasonStats>>
    {
        public List<DefenseSeasonStats> obj { get; set; }
        private DefSeasonStatsHandler handler;

        public MultipleDssHandler(List<DefenseSeasonStats> seasonStats)
        {
            obj = seasonStats;
            handler = new DefSeasonStatsHandler();
        }
        public void Fetch()
        {
            foreach(DefenseSeasonStats seasonStats in obj)
            {
                handler.obj = seasonStats;
                handler.Fetch();
            }
        }
        public int Post()
        {
            int effected = 0;
            foreach(DefenseSeasonStats seasonStats in obj)
            {
                handler.obj = seasonStats;
                effected += handler.Post();
            }
            return effected;
        }
        public int Put()
        {
            int effected = 0;
            foreach(DefenseSeasonStats seasonStats in obj)
            {
                handler.obj = seasonStats;
                effected += handler.Put();
            }
            return effected;
        }
        public int Delete()
        {
            int effected = 0;
            foreach (DefenseSeasonStats seasonStats in obj)
            {
                handler.obj = seasonStats;
                effected += handler.Delete();
            }
            return effected;
        }


    }
}