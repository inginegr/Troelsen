using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Drawing;
using System.Security.Cryptography;
using System.Data.Entity;



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

        public ICollection<Player> Players { get; set; }
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
                
                //List<Player> pol = new List<Player>
                //{
                //    new Player { Id=1, Name="Fona", Position="sdf", Age=34},
                //    new Player {Id=2, Name="Lond", Position="rrr", Age=45}
                //};

                //db.Players.AddRange(pol);

                //db.SaveChanges();

                db.Players.ForEachAsync(x =>
                {
                    Console.WriteLine($"{x.Id}   {x.Name}");
                });

                Console.ReadLine();
            }
        }
    }
}