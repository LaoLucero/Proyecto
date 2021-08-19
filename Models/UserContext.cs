using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Proyecto.Models
{
    public class UserContext : DbContext
    {
        
        public DbSet<User> User { get; set; }

        public UserContext() : base()
        {

        }


        public UserContext(DbContextOptions<DbContext> options) : base (options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                IConfigurationRoot configuration = new ConfigurationBuilder()
                   .SetBasePath(Directory.GetCurrentDirectory())
                   .AddJsonFile("appsettings.json")
                   .Build();
                var connectionString = configuration.GetConnectionString("ConnectionStrings");
                optionsBuilder.UseSqlServer("Server=localhost;Database=Proyecto;User Id=sa;Password=LaoLucero97;");
            }
        }

        internal static UserContext OrderBy(Func<object, bool> p)
        {
            throw new NotImplementedException();
        }
    }
}
