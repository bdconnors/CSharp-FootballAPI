using FootballAPI.Models;
using FootballAPI.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FootballAPI.Util
{
    public class MultipleDgsHandler : IDataAccessLayer<List<DefenseGameStats>>
    {
        public List<DefenseGameStats> obj { get; set; }
        private DefGameStatsHandler handler;

        public MultipleDgsHandler(List<DefenseGameStats> gameStats)
        {
            obj = gameStats;
            handler = new DefGameStatsHandler();
        }
        public void Fetch()
        {
            foreach(DefenseGameStats gameStats in obj)
            {
                handler.obj = gameStats;
                handler.Fetch();
            }
        }
        public int Post()
        {
            int effected = 0;
            foreach(DefenseGameStats gameStats in obj)
            {
                handler.obj = gameStats;
                effected += handler.Post();
            }
            return effected;
        }
        public int Put()
        {
            int effected = 0;
            foreach(DefenseGameStats gameStats in obj)
            {
                handler.obj = gameStats;
                effected += handler.Put();
            }
            return effected;
        }
        public int Delete()
        {
            int effected = 0;
            foreach (DefenseGameStats gameStats in obj)
            {
                handler.obj = gameStats;
                effected += handler.Delete();
            }
            return effected;
        }


    }
}