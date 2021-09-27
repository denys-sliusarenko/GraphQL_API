using GraphQL_API.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQL_API.Classes
{
    public class Mutation
    {
        private readonly DatabaseContext dbContext;

        public Mutation(DatabaseContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<User> Create(string firstName,string lastName)
        {
            User user = new User() { FirstName = firstName, LastName = lastName };
            await dbContext.Users.AddAsync(user);
            await dbContext.SaveChangesAsync();
            return user;
        }
    }
}
