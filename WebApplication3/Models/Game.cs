using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication3.Models
{
    public class Game
    {
        
       public int GameId { get; set; }
        [DisplayName("Home")]
        public string HomeTeam { get; set; }
        
        [DisplayName("Away")]
        public string AwayTeam { get; set; }

        public string Venue { get; set; }

        [DisplayName("Home Score")]
        public int HomeScore { get; set; }

        [DisplayName("Away Score")]
        public int AwayScore { get; set; }
     
        public bool Win { get; set; }


        [DisplayName("FG")]
        public decimal FGM { get; set; }
        
        public decimal FGA { get; set; }

        [DisplayName("FG%")]
        public decimal FGperC { get; set; }

        [DisplayName("2P")]
        public decimal Two_PM { get; set; }

        [DisplayName("2PA")]
        public decimal Two_PA { get; set; }

        [DisplayName("2P%")]
        public decimal TwoPerC { get; set; }

        [DisplayName("3PA")]
        public decimal Three_PA { get; set; }

        [DisplayName("3P")]
        public decimal Three_PM { get; set; }

        [DisplayName("3P%")]
        public decimal Three_PC { get; set; }

        [DisplayName("FT")]
        public int FTM { get; set; }

        [DisplayName("FTA")]
        public int FTA { get; set; }

        [DisplayName("FT%")]
        public decimal FT_PC { get; set; }

        [DisplayName("ORB")]
        public int O_Rb { get; set; }

        [DisplayName("DRB")]
        public int D_Rb { get; set; }

        [DisplayName("TRB")]
        public int Total_Reb { get; set; }
        public int AST { get; set; }
        public int TO { get; set; }
        
        [DisplayName("STL")]
        public int Steal { get; set; }

        [DisplayName("BLK")] 
        public int Block { get; set; }

        [DisplayName("PTS")]
        public int Points { get; set; }

        public string Notes { get; set; }

    }
}



