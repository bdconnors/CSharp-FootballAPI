using FootballAPI.Models;
using FootballAPI.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FootballAPI.Services
{
    public class PlayerGameLogHandler : IDataAccessLayer<PlayerGameLog>
    {
        public static Database db = new Database();
        public PlayerGameLog obj { get; set; }

        public PlayerGameLogHandler(PlayerGameLog player)
        {
            obj = player;
        }
        public PlayerGameLogHandler()
        {

        }
        public void Fetch()
        {
            PlayerHandler playerAccess = new PlayerHandler(obj.player);
            playerAccess.Fetch();
            GameHandler gameAccess = new GameHandler(obj.game);
            gameAccess.Fetch();
            TeamHandler teamAccess = new TeamHandler(obj.team = new Team(obj.player.team));
            teamAccess.Fetch();
            PlayerGameStatsHandler statsAccess = new PlayerGameStatsHandler(obj.stats = new PlayerGameStats(obj.player.playerid,obj.game.gameid));
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