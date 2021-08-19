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
    public class Service : DbContext
    {
        
        public DbSet<User> User { get; set; }

        public Service() : base()
        {

        }


        public Service(DbContextOptions<DbContext> options) : base (options)
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

        public async Task<IEnumerable<User>> ListUsers()
        {
            var userList = await User.ToListAsync();
            return userList;
        }

        public async Task<User> GetUserById(int id )
        {
            var user = await User.FirstOrDefaultAsync(x => x.Id == id);
            return user;
        }

        public async Task<User> CreateAsync(User user)
        {
            var newUser = await User.AddAsync(user);

            return newUser.Entity;

        }

        internal static Service OrderBy(Func<object, bool> p)
        {
            throw new NotImplementedException();
        }
    }
}
