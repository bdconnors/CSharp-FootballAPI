using FootballAPI.DataLayer.Models;
using FootballAPI.DataLayer.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace FootballAPI.Controllers
{
    [Route("v1.0/GameLogs")]
    public class GameLogsController : ApiController
    {
        [Route("v1.0/GameLogs/Player/{playerid}/Game/{gameid}")]
        public Object GetGame(string playerid, string gameid)
        {
            Player player = new Player(playerid);
            PlayerGameService service = new PlayerGameService();
            try
            {
                service.Get(player,gameid);
            }
            catch (Exception e)
            {
                return e;
            }
            return player;
        }
        [Route("v1.0/GameLogs/Player/{playerid}")]
        public Object GetAllGameLogs(string playerid)
        {
            Player player = new Player(playerid);
            PlayerGameService service = new PlayerGameService();
            try
            {
                service.Get(player);
            }
            catch (Exception e)
            {
                return e;
            }
            return player;
        }
        [Route("v1.0/GameLogs/Player/Game/{gameid}")]
        public Object GetAllPlayerGameLogs(string gameid)
        {
            PlayerGameLogs players = new PlayerGameLogs();
            PlayerGameService service = new PlayerGameService();
            try
            {
                service.Get(players,gameid);
            }
            catch (Exception e)
            {
                return e;
            }
            return players;
        }
        [Route("v1.0/GameLogs/Defense/{team}/Game/{gameid}")]
        public Object GetDefGame(string team, string gameid)
        {
            Defense defense = new Defense(team);
            DefenseGameService service = new DefenseGameService();
            try
            {
                service.Get(defense, gameid);
            }
            catch (Exception e)
            {
                return e;
            }
            return defense;
        }
        [Route("v1.0/GameLogs/Defense/{team}")]
        public Object GetAllDefGameLogs(string team)
        {
            Defense defense = new Defense(team);
            DefenseGameService service = new DefenseGameService();
            try
            {
                service.Get(defense);
            }
            catch (Exception e)
            {
                return e;
            }
            return defense;
        }
        [Route("v1.0/GameLogs/Defense/Game/{gameid}")]
        public Object GetAllDefenseGame(string gameid)
        {
            DefenseLogs defenses = new DefenseLogs();
            DefenseGameService service = new DefenseGameService();
            try
            {
                service.Get(defenses, gameid);
            }
            catch (Exception e)
            {
                return e;
            }
            return defenses;
        }
        [Route("v1.0/GameLogs/Defense/")]
        public Object GetAllDefenseGameLogs()
        {
            DefenseLogs defenses = new DefenseLogs();
            DefenseGameService service = new DefenseGameService();
            try
            {
                service.Get(defenses);
            }
            catch (Exception e)
            {
                return e;
            }
            return defenses;
        }

    }
}
