using FootballAPI.Models;
using FootballAPI.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FootballAPI.Util
{
    public class MultiplePgsHandler : IDataAccessLayer<List<PlayerGameStats>>
    {
        public List<PlayerGameStats> obj { get; set; }
        private PlayerGameStatsHandler handler;

        public MultiplePgsHandler(List<PlayerGameStats> gameStats)
        {
            obj = gameStats;
            handler = new PlayerGameStatsHandler();
        }
        public void Fetch()
        {
            foreach(PlayerGameStats gameStats in obj)
            {
                handler.obj = gameStats;
                handler.Fetch();
            }
        }
        public int Post()
        {
            int effected = 0;
            foreach(PlayerGameStats gameStats in obj)
            {
                handler.obj = gameStats;
                effected += handler.Post();
            }
            return effected;
        }
        public int Put()
        {
            int effected = 0;
            foreach(PlayerGameStats gameStats in obj)
            {
                handler.obj = gameStats;
                effected += handler.Put();
            }
            return effected;
        }
        public int Delete()
        {
            int effected = 0;
            foreach (PlayerGameStats gameStats in obj)
            {
                handler.obj = gameStats;
                effected += handler.Delete();
            }
            return effected;
        }


    }
}