using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication3.Models
{
    public class Player

    {
        public int PlayerID { get; set; }
        public int TeamID { get; set; }
        public string Name { get; set; }
        public int Number { get; set; }

        public Team TeamName { get; set; }
        

    }
}
