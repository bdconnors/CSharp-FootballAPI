using FootballAPI.Models;
using FootballAPI.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FootballAPI.Util
{
    public class MultiplePlayerHandler : IDataAccessLayer<List<Player>>
    {
        public List<Player> obj { get; set; }
        private PlayerHandler handler;

        public MultiplePlayerHandler(List<Player> players)
        {
            obj = players;
            handler = new PlayerHandler();
        }
        public void Fetch()
        {
            foreach(Player player in obj)
            {
                handler.obj = player;
                handler.Fetch();
            }
        }
        public int Post()
        {
            int effected = 0;
            foreach(Player player in obj)
            {
                handler.obj = player;
                effected += handler.Post();
            }
            return effected;
        }
        public int Put()
        {
            int effected = 0;
            foreach(Player player in obj)
            {
                handler.obj = player;
                effected += handler.Put();
            }
            return effected;
        }
        public int Delete()
        {
            int effected = 0;
            foreach (Player player in obj)
            {
                handler.obj = player;
                effected += handler.Delete();
            }
            return effected;
        }


    }
}