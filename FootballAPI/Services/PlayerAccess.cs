using FootballAPI.Models;
using FootballAPI.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FootballAPI.Services
{
    public class PlayerAccess : IDataAccessLayer<Player>
    {
        public static Database db = new Database();
        public Player obj { get; set; }

        public PlayerAccess(Player player)
        {
            obj = player;
        }
        public PlayerAccess()
        {

        }
        public void Fetch()
        {
            string sql = "SELECT * FROM Player WHERE playerid = @playerid";
            Dictionary<string, string> values = new Dictionary<string, string>() { { "@playerid", obj.playerid } };
            string[] queryResult = db.GetData(sql, values)[0];
            obj.fname = queryResult[1];
            obj.lname = queryResult[2];
            obj.number = queryResult[3];
            obj.position = queryResult[4];
            obj.team = queryResult[5];
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