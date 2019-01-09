using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FootballAPI.DataLayer.Models
{
    public class DefenseStats
    {
        public string pa { get; set; }
        public string sck { get; set; }
        public string fum { get; set; }
        public string intc { get; set; }
        public string intTd { get; set; }
        public string fumTd { get; set; }
        public string sfty { get; set; }
        public string krTd { get; set; }
        public string prTd { get; set; }
        public string fgBlk { get; set; }
        public string xpBlk { get; set; }
    }
}