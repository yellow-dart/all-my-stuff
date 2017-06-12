using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GamesListWeb.Models
{
    public class Nes
    {
        public string Name { get; set; }
        public string NumberOfPlayers { get; set; }
        public string Type { get; set; }
        public string Save { get; set; }
        public string SimultaneousTurn { get; set; }
        public string NumberOfScrews { get; set; }
        public string Instructions { get; set; }
        public string Box { get; set; }
        public string MarkingsEtc { get; set; }
        public string Publisher { get; set; }
        public string Feature { get; set; }
    }
}
