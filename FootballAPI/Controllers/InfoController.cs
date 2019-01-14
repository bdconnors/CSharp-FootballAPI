using FootballAPI.DataLayer;
using FootballAPI.DataLayer.Models;
using FootballAPI.DataLayer.Services;
using FootballAPI.DataLayer.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace FootballAPI.Controllers
{
    [Route("v1.0/PlayerInfo")]
    public class InfoController : ApiController
    {

        [Route("v1.0/PlayerInfo/")]
        public Object GetAll()
        {
            PlayerInfoLog players = new PlayerInfoLog();
            PlayerInfoService service = new PlayerInfoService();
            try
            {
                service.Get(players);
            }
            catch(Exception e)
            {
                return e;
            }
            return players;
        }
        [Route("v1.0/PlayerInfo/{playerid}")]
        public Object GetPlayer(string playerid)
        {
            Player player = new Player(playerid);
            PlayerInfoService service = new PlayerInfoService();
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
        [Route("v1.0/PlayerInfo/Position/{position}")]
        public Object GetByPosition(string position)
        {
            PlayerInfoLog players = new PlayerInfoLog();
            PlayerInfoService service = new PlayerInfoService();
            try
            {
                service.Get(players,position);
            }
            catch (Exception e)
            {
                return e;
            }
            return players;
        }
    }
}
