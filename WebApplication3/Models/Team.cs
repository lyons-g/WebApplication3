using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication3.Models
{
    public class Team
    {
        public int TeamID { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
      //  public Coach Coach { get; set; }
       // public ICollection<Game>Games { get; set; }
        public ICollection<Player>Roster { get; set; }
    }
}
