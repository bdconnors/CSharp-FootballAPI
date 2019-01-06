using FootballAPI.Models;
using FootballAPI.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FootballAPI.Services
{
    public class PlayerHandler : IDataAccessLayer<Player>
    {
        public static Database db = new Database();
        public Player obj { get; set; }

        public PlayerHandler(Player player)
        {
            obj = player;
        }
        public PlayerHandler()
        {

        }
        public void Fetch()
        {
            string sql = "SELECT * FROM Player WHERE playerid = @playerid";
            Dictionary<string, string> values = new Dictionary<string, string>() { { "@playerid", obj.playerid } };
            obj.Set(db.GetData(sql, values)[0]);
        }
        public int Post()
        {
            string sql = "INSERT INTO Player(Playerid,fname,lname,number,Position,team)VALUES(@Playerid,@fname,@lname,@number,@Position,@team)";
            Dictionary<string, string> values = new Dictionary<string, string>();
            values.Add("@Playerid", obj.playerid);
            values.Add("@fname", obj.fname);
            values.Add("@lname", obj.lname);
            values.Add("@number", obj.number);
            values.Add("@Position", obj.position);
            values.Add("@team", obj.team);
            return db.SetData(sql, values);
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