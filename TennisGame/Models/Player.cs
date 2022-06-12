using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TennisGame.Models
{
    /// <summary>
    /// Denna klass är till för att hantera värden som sedan visas upp i interfacet.
    /// </summary>
    public class Player
    {
        public int PlayerNumber { get; set; } = 0;
        public string PlayerName { get; set; } = "";
        public int PlayerScoreCounter { get; set; } = 0;
        public int PlayerGameCounter { get; set; } = 0;
        public int PlayerSetCounter { get; set; } = 0;
        public string PlayerSetsWon { get; set; } = "0";
        public string PlayerScoreLabel { get; set; } = "0";
        public string PlayerScoreLabelString { get; set; } = "Love";
    }
}
