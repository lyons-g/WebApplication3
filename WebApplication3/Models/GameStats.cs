using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication3.Models
{
    public class GameStats
    {
        [Key]
        public int GamesStatsID {get; set;}
        
        public int Rebound { get; set; }
        public int Points { get; set;  }
        public int Turnovers { get; set; }

        public int GameID { get; set; }
        public Game Game { get; set; }
    }
}
