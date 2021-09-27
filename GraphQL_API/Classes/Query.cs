using GraphQL_API.Entities;
using HotChocolate;
using HotChocolate.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQL_API.Classes
{
    public class Query
    {
        private readonly DatabaseContext dbContext;

        public Query(DatabaseContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public List<User> Users()
        {
            using (var context = new DatabaseContext(GetDbOptions()))
            {
                return context.Users.ToList();
            }
        }

        private DbContextOptions<DatabaseContext> GetDbOptions()
        {
            string dbName = "GraphQL_API_database";

            var serviceProvider = new ServiceCollection()
                .AddEntityFrameworkInMemoryDatabase()
                .BuildServiceProvider();

            var builder = new DbContextOptionsBuilder<DatabaseContext>();
            builder.UseInMemoryDatabase(dbName)
                   .UseInternalServiceProvider(serviceProvider);
            using (var context = new DatabaseContext(builder.Options))
            {
                context.Users.AddRange(GetTestUsers());
                context.SaveChanges();
            }
            return builder.Options;
        }

        private List<User> GetTestUsers()
        {
            var users = new List<User>
            {
                new User
                {
                    FirstName="Tom",
                    LastName="Walker"
                },
                new User
                {
                    FirstName="Alice",
                    LastName="Walker"
                },
                new User
                {
                    FirstName="Sam",
                    LastName="Walker"
                }
            };
            return users;
        }

    }
}