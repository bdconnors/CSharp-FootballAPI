using FootballAPI.DataLayer.Models;
using FootballAPI.DataLayer.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FootballAPI.DataLayer.Util
{
    public class LoadPlayers
    {
        private Season season { get; set; }
        private PlayerRequest request;


        public LoadPlayers(Season season)
        {
            request = new PlayerRequest(season);
        }

        public int loadSeasonStats()
        {
            int effected = 0;
            List<Player> players = request.GetSeasonStats();
            PlayerService service = new PlayerService();
            foreach(Player player in players)
            {
                service.player = player;
                try
                {   if (service.Exists())
                    {
                        effected += service.PostSeasonLog();
                    }
                }
                catch(Exception e)
                {
                    effected = -1;
                    throw new Exception(e.Message, e);
                }
            }
            return effected;
        }
        public int loadGameStats(string team,string position)
        {
            int effected = 0;
            List<Player> players = request.GetGameStats(team,position);
            PlayerService service = new PlayerService();
            foreach (Player player in players)
            {
                service.player = player;
                try
                {
                    if (service.Exists())
                    {
                        effected += service.PostGameLogs();
                    }
                }
                catch (Exception e)
                {
                    effected = -1;
                    throw new Exception(e.Message,e);
                }
            }
            return effected;
        }
    }
}