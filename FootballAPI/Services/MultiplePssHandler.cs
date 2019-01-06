using FootballAPI.Models;
using FootballAPI.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FootballAPI.Util
{
    public class MultiplePssHandler : IDataAccessLayer<List<PlayerSeasonStats>>
    {
        public List<PlayerSeasonStats> obj { get; set; }
        private PlayerSeasonStatsHandler handler;

        public MultiplePssHandler(List<PlayerSeasonStats> seasonStats)
        {
            obj = seasonStats;
            handler = new PlayerSeasonStatsHandler();
        }
        public void Fetch()
        {
            foreach(PlayerSeasonStats seasonStats in obj)
            {
                handler.obj = seasonStats;
                handler.Fetch();
            }
        }
        public int Post()
        {
            int effected = 0;
            foreach(PlayerSeasonStats seasonStats in obj)
            {
                handler.obj = seasonStats;
                effected += handler.Post();
            }
            return effected;
        }
        public int Put()
        {
            int effected = 0;
            foreach(PlayerSeasonStats seasonStats in obj)
            {
                handler.obj = seasonStats;
                effected += handler.Put();
            }
            return effected;
        }
        public int Delete()
        {
            int effected = 0;
            foreach (PlayerSeasonStats seasonStats in obj)
            {
                handler.obj = seasonStats;
                effected += handler.Delete();
            }
            return effected;
        }


    }
}