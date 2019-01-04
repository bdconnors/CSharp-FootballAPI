using FootballAPI.Models;
using FootballAPI.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FootballAPI.Services
{
    public class GameAccess : IDataAccessLayer<Game>
    {
        public static Database db = new Database();
        public Game obj { get; set; }

        public GameAccess(Game game)
        {
            obj = game;
        }
        public GameAccess()
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