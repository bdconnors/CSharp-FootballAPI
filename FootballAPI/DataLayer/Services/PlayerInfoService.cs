using FootballAPI.DataLayer.Models;
using FootballAPI.DataLayer.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;

namespace FootballAPI.DataLayer.Services
{
    public class PlayerInfoService : Database
    {
        public void Get(PlayerInfoLog players, string position)
        {
            try
            {
                Dictionary<string, string> values = new Dictionary<string, string>() { { "@pos", position } };
                List<string[]> results = SelectProc("GetPlayersByPosition", values);
                Player currentPlayer;
                foreach (string[] result in results)
                {
                    currentPlayer = new Player();
                    currentPlayer.player.playerid = result[0];
                    currentPlayer.player.fname = result[1];
                    currentPlayer.player.lname = result[2];
                    currentPlayer.player.number = result[3];
                    currentPlayer.player.position = result[4];
                    currentPlayer.team.abbr = result[5];
                    currentPlayer.team.city = result[6];
                    currentPlayer.team.name = result[7];
                    players.playerinformation.Add(currentPlayer);
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message, e);
            }
        }
        public void Get(PlayerInfoLog players)
        {
            try
            {
                List<string[]> results = SelectProc("GetAllPlayers", null);
                Player currentPlayer;
                foreach (string[] result in results)
                {
                    currentPlayer = new Player();
                    currentPlayer.player.playerid = result[0];
                    currentPlayer.player.fname = result[1];
                    currentPlayer.player.lname = result[2];
                    currentPlayer.player.number = result[3];
                    currentPlayer.player.position = result[4];
                    currentPlayer.team.abbr = result[5];
                    currentPlayer.team.city = result[6];
                    currentPlayer.team.name = result[7];
                    players.playerinformation.Add(currentPlayer);
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message, e);
            }
        }
        public void Get(Player player)
        {
            try
            {
                Dictionary<string, string> values = new Dictionary<string, string>() { { "@pid", player.player.playerid } };
                string[] result = SelectProc("GetPlayer", values)[0];
                player.player.playerid = result[0];
                player.player.fname = result[1];
                player.player.lname = result[2];
                player.player.number = result[3];
                player.player.position = result[4];
                player.team.abbr = result[5];
                player.team.city = result[6];
                player.team.name = result[7];
            }
            catch(Exception e)
            {
                throw new Exception(e.Message, e);
            }
        }
        public bool Exists(Player player)
        {
            string sql = "SELECT * FROM Player WHERE PlayerID = @Playerid";
            int record;
            bool exists = false;
            Dictionary<string, string> values = new Dictionary<string, string>() { { "@PlayerID", player.player.playerid } };
            try
            {
                record = SelectStmt(sql, values).Count;
                if(record == 0)
                {
                    exists = false;
                }
                else
                {
                    exists = true;
                }
            }
            catch(Exception e)
            {           
                throw new Exception(e.Message, e);
            }
            return exists;
        }
    }
}