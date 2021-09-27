using GraphQL_API.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQL_API.Classes
{
    public class DatabaseContext : DbContext
    {

        public DbSet<User> Users { get; set; }
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData(
                new User[]
                {
                    new User()
                    {
                        UserId = 1,
                        FirstName = "Tom",
                        LastName = "Wolker"
                    },
                    new User()
                    {
                         UserId = 2,
                         FirstName = "Adam",
                         LastName = "Wolker"
                    },
                    new User()
                    {
                        UserId = 3,
                        FirstName = "Alice",
                        LastName = "Wolker"
                    },
                });
        }
    }
}
