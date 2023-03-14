using System;
using System.Reflection.Metadata;
using Microsoft.EntityFrameworkCore;
using MyApp.Data.Models;

namespace MyApp.Data
{
	public class MyAppDbContext : DbContext
	{
        public MyAppDbContext(DbContextOptions<DbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
        }

        public DbSet<Credit> Credit { get; set; }
        public DbSet<ClientCredit> ClientCredit { get; set; }
    }
}

