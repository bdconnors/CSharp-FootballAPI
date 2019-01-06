using FootballAPI.Models;
using FootballAPI.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FootballAPI.Services
{
    public class PlayerSeasonLogHandler : IDataAccessLayer<PlayerSeasonLog>
    {
        public static Database db = new Database();
        public PlayerSeasonLog obj { get; set; }

        public PlayerSeasonLogHandler(PlayerSeasonLog player)
        {
            obj = player;
        }
        public PlayerSeasonLogHandler()
        {

        }
        public void Fetch()
        {
            PlayerHandler playerAccess = new PlayerHandler(obj.player);
            playerAccess.Fetch(); 
            TeamHandler teamAccess = new TeamHandler(obj.team = new Team(obj.player.team));
            teamAccess.Fetch();
            PlayerSeasonStatsHandler statsAccess = new PlayerSeasonStatsHandler(obj.stats = new PlayerSeasonStats(obj.player.playerid));
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