using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using GamesProject.DataAccessLayer.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace GamesProject.DataAccessLayer.EntitiFramework
{
    public class DataContext:DbContext
    {

        public DataContext(DbContextOptions<DataContext> options)
            : base(options)
        {
           
        }
        public DbSet<User> Users { get; set; }
        public DbSet<HighScore> HScoresShellGame { get; set; }

    }
}
