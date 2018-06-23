using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Z_DataAccessLayer.Entities;


namespace Z_DataAccessLayer.EntitiFramework
{
    public class DataContext : DbContext
    {
        public DbSet<User> Users {get; set;}
        public DbSet<HighScore> HScores { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb; Database=GamesDB; Trusted_Connection=True");
        }
    }
}
