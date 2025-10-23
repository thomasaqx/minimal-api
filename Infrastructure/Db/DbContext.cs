using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using minimal_api.Domains.Entities;

namespace minimal_api.Infrastructure.Db
{
    public class AppDbContext : DbContext
    {

        private readonly IConfiguration _configurationAppSetings;
        public AppDbContext(IConfiguration configurationAppSetings)
        {
            _configurationAppSetings = configurationAppSetings;
        }




        public DbSet<Administrator> Administrators { get; set; } = default!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Administrator>().HasData(
                new Administrator
                {
                    id = 1,
                    Email = "adm@test.com",
                    Password = "123456",
                    Profile = "Adm"

                });
        }



        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var stringConnection = _configurationAppSetings.GetConnectionString("mysql").ToString();

            if (!string.IsNullOrEmpty(stringConnection))
                optionsBuilder.UseMySql(stringConnection, ServerVersion.AutoDetect(stringConnection));

        }
    }
}