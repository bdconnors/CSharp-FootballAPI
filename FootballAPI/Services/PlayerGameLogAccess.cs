using FootballAPI.Models;
using FootballAPI.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FootballAPI.Services
{
    public class PlayerGameLogAccess : IDataAccessLayer<PlayerGameLog>
    {
        public static Database db = new Database();
        public PlayerGameLog obj { get; set; }

        public PlayerGameLogAccess(PlayerGameLog player)
        {
            obj = player;
        }
        public PlayerGameLogAccess()
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