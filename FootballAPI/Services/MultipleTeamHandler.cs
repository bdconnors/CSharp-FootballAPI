using FootballAPI.Models;
using FootballAPI.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FootballAPI.Util
{
    public class MultipleTeamHandler : IDataAccessLayer<List<Team>>
    {
        public List<Team> obj { get; set; }
        private TeamHandler handler;

        public MultipleTeamHandler(List<Team> team)
        {
            obj = team;
            handler = new TeamHandler();
        }
        public void Fetch()
        {
            foreach(Team team in obj)
            {
                handler.obj = team;
                handler.Fetch();
            }
        }
        public int Post()
        {
            int effected = 0;
            foreach(Team team in obj)
            {
                handler.obj = team;
                effected += handler.Post();
            }
            return effected;
        }
        public int Put()
        {
            int effected = 0;
            foreach(Team team in obj)
            {
                handler.obj = team;
                effected += handler.Put();
            }
            return effected;
        }
        public int Delete()
        {
            int effected = 0;
            foreach (Team team in obj)
            {
                handler.obj = team;
                effected += handler.Delete();
            }
            return effected;
        }


    }
}