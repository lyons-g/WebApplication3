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
            if(context.Teams.Any())
            {
                return;
            }
            var teams = new Team[]
            {
                new Team { Name = "Moycullen", Address = "Galway"},
                new Team {Name = "UCD", Address = "Dublin"},
                new Team {Name = "Star", Address = "Belfast"}
            };
            foreach(Team t in teams)
            {
                context.Teams.Add(t);
            }
            context.SaveChanges();

            var players = new Player[]
            {
                new Player
                {
                    TeamID = teams.Single(t=>t.Name == "Moycullen").TeamID,
                    Name = "Patrick Lyons", Number = 4
                },

                 new Player
                {
                    TeamID = teams.Single(t=>t.Name == "Moycullen").TeamID,
                    Name = "James Lyons", Number = 5

                },

                  new Player
                {
                    TeamID = teams.Single(t=>t.Name == "Moycullen").TeamID,
                    Name = "Laura Lyons", Number = 6

                },

                   new Player
                {
                    TeamID = teams.Single(t=>t.Name == "UCD").TeamID,
                    Name = "Kev Foley", Number = 10
                },

                    new Player
                {
                    TeamID = teams.Single(t=>t.Name == "Star").TeamID,
                    Name = "Barry Jackson", Number = 11

                }
            };
            foreach (Player p in players)
            {
                var playersInDataBase = context.Players.Where(
                    t => t.TeamID == p.PlayerID).SingleOrDefault();
                if (playersInDataBase == null)
                {
                    context.Players.Add(p);
                }
            }
                context.SaveChanges();
            }
        }
    }

