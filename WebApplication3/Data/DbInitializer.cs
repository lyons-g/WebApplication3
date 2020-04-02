using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using WebApplication3.Models;

namespace WebApplication3.Data
{
    public static class DbInitializer
    {
        public static void Initialize(ApplicationDbContext context)
        {
            if (context.Games.Any())
            {
                return;
            }
            var games = new Game[]
            {
                new Game { HomeTeam = "Moycullen", AwayTeam = "Maree", HomeScore = 55, AwayScore = 25 },
                new Game {HomeTeam = "UCD", AwayTeam = "Moycullen", HomeScore = 25, AwayScore = 55},
                new Game {HomeTeam = "Moycullen", AwayTeam = "Lions", HomeScore = 45, AwayScore = 30 }
            };
            foreach (Game g in games)
            {
                context.Games.Add(g);
            }
            context.SaveChanges();


        }
    }

}