using FootballAPI.Models;
using FootballAPI.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FootballAPI.Services
{
    public class PlayerSeasonLogAccess : IDataAccessLayer<PlayerSeasonLog>
    {
        public static Database db = new Database();
        public PlayerSeasonLog obj { get; set; }

        public PlayerSeasonLogAccess(PlayerSeasonLog player)
        {
            obj = player;
        }
        public PlayerSeasonLogAccess()
        {

        }
        public void Fetch()
        {
            PlayerAccess playerAccess = new PlayerAccess(obj.player);
            playerAccess.Fetch(); 
            TeamAccess teamAccess = new TeamAccess(obj.team = new Team(obj.player.team));
            teamAccess.Fetch();
            PlayerSeasonStatsAccess statsAccess = new PlayerSeasonStatsAccess(obj.stats = new PlayerSeasonStats(obj.player.playerid));
            statsAccess.Fetch();               
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