using System;
using Microsoft.Entityframeworkcore;
using Microsoft.Entityframework.sqlite;

namespace Buffteks
{

    public class AppDbContext : DbContext
    {

        private const string ConnectionString = @"Data Source=MyFirstCoreDb.db";

        protected override void OnConfiguring(
            DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(ConnectionString);
        }

        public DBset<Student> Students {get; set;}

    }

}