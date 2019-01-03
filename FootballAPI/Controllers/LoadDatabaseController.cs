using FootballAPI.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace FootballAPI.Controllers
{
    public class LoadDatabaseController : ApiController
    {
        
        // POST: api/LoadDatabase/Teams
        public int Post()
        {
            LoadTeams load = new LoadTeams(2018);
            return load.Load();
        }

   
    }
}
