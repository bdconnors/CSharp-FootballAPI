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
    [Route("api/Player")]
    public class PlayerController : ApiController
    {


        [Route("api/Player/{id}")]
        public Object Get(string id)
        {
            Player player = new Player(new PlayerInfo(id));
            PlayerService service = new PlayerService(player);
            try
            {                         
                service.GetInfo();
                service.GetSeasonLog();
            }
            catch(Exception e)
            {             
                return e;
            }
            return player;
        }


    }
}
