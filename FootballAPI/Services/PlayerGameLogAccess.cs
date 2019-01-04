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
            PlayerAccess playerAccess = new PlayerAccess(obj.player);
            playerAccess.Fetch();
            GameAccess gameAccess = new GameAccess(obj.game);
            gameAccess.Fetch();
            TeamAccess teamAccess = new TeamAccess(obj.team = new Team(obj.player.team));
            teamAccess.Fetch();
            PlayerGameStatsAccess statsAccess = new PlayerGameStatsAccess(obj.stats = new PlayerGameStats(obj.player.playerid,obj.game.gameid));
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