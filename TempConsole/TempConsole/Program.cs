using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Drawing;
using System.Security.Cryptography;
using System.Data.Entity;
using System.Linq;



namespace TempConsole
{
    public class Player
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Position { get; set; }
        public int Age { get; set; }

        public int? TeamId { get; set; }
        public Team Team { get; set; }
    }
    public class Team
    {
        public int Id { get; set; }
        public string Name { get; set; } // название команды

        public virtual List<Player> Players { get; set; }
        public Team()
        {
            Players = new List<Player>();
        }
    }
    public class SoccerContext : DbContext
    {
        public SoccerContext() : base("DefaultConnection")
        { }

        public DbSet<Player> Players { get; set; }
        public DbSet<Team> Teams { get; set; }
    }
    class Program
    {
        
        static void Main(string[] args)
        {
            using (SoccerContext db = new SoccerContext())
            {
                // создание и добавление моделей

                List<Team> tm = new List<Team>();

                Team t1 = new Team { Name = "asdasd" };
                Team t2 = new Team { Name = "213123" };
                Team t3 = new Team { Name = "3432sdf" };
                tm.Add(t1);
                tm.Add(t2);
                tm.Add(t3);
                db.Teams.AddRange(tm);


                List<Player> pol = new List<Player>
                {
                    new Player { Id=1, Name="Fona", Position="sdf", Age=34, Team=t1},
                    new Player {Id=2, Name="Lond", Position="rrr", Age=45, Team=t1},
                    new Player {Id=2, Name="Lond", Position="rrr", Age=45, Team=t1},
                    new Player {Id=2, Name="Lond", Position="rrr", Age=45, Team=t2},
                    new Player {Id=2, Name="Lond", Position="rrr", Age=45, Team=t2}
                };

                db.Players.AddRange(pol);

                db.SaveChanges();

                List<Team> list = new List<Team>();

                Team lt = db.Teams.Where(x => x.Name == "asdasd").FirstOrDefault();

                Console.WriteLine($"The team is {lt.Name}");

                foreach(Player p in lt.Players)
                {
                    Console.WriteLine($"{p.Name}   {p.TeamId}");
                }

                Console.ReadLine();
            }
        }
    }
}