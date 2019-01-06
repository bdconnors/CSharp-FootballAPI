using FootballAPI.Models;
using FootballAPI.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FootballAPI.Util
{
    public class MultipleGameHandler : IDataAccessLayer<List<Game>>
    {
        public List<Game> obj { get; set; }
        private GameHandler handler;

        public MultipleGameHandler(List<Game> games)
        {
            obj = games;
            handler = new GameHandler();
        }
        public void Fetch()
        {
            foreach(Game game in obj)
            {
                handler.obj = game;
                handler.Fetch();
            }
        }
        public int Post()
        {
            int effected = 0;
            foreach(Game game in obj)
            {
                handler.obj = game;
                if (!handler.Exists())
                { effected += handler.Post(); }
            }
            return effected;
        }
        public int Put()
        {
            int effected = 0;
            foreach(Game game in obj)
            {
                handler.obj = game;
                effected += handler.Put();
            }
            return effected;
        }
        public int Delete()
        {
            int effected = 0;
            foreach (Game game in obj)
            {
                handler.obj = game;
                effected += handler.Delete();
            }
            return effected;
        }


    }
}