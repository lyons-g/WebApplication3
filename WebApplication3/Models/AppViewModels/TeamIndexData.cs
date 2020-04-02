using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication3.Models;

namespace WebApplication3.Models.AppViewModels
{
    public class TeamIndexData
    {
        public IEnumerable<Team> Teams { get; set; }
        public IEnumerable<Player> Players { get; set; }
    }
}
