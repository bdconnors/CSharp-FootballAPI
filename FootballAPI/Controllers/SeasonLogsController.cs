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
    [Route("v1.0/SeasonLogs")]
    public class SeasonLogsController : ApiController
    {
        [Route("v1.0/SeasonLogs/Player/")]
        public Object GetAllSeasonStats()
        {
            PlayerSeasonLogs players = new PlayerSeasonLogs();
            PlayerSeasonService service = new PlayerSeasonService();
            try
            {
                service.Get(players);
            }
            catch (Exception e)
            {
                return e;
            }
            return players;
        }
        [Route("v1.0/SeasonLogs/Player/Position/{position}")]
        public Object GetSeasonStatsByPosition(string position)
        {
            PlayerSeasonLogs players = new PlayerSeasonLogs();
            PlayerSeasonService service = new PlayerSeasonService();
            try
            {
                service.Get(players);
            }
            catch (Exception e)
            {
                return e;
            }
            return players;
        }
        [Route("v1.0/SeasonLogs/Player/{playerid}")]
        public Object GetSeasonStatsByPlayerID(string playerid)
        {
            Player player = new Player(playerid);
            PlayerSeasonService service = new PlayerSeasonService();
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
        [Route("v1.0/SeasonLogs/Defense/{team}")]
        public Object GetAllDefenseSeasonLogs(string team)
        {
            Defense defense = new Defense(team);
            DefenseSeasonService service = new DefenseSeasonService();
            
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
        [Route("v1.0/SeasonLogs/Defense/")]
        public Object GetAllDefSeasonStats()
        {
            DefenseLogs defenses = new DefenseLogs();
            DefenseSeasonService service = new DefenseSeasonService();
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
