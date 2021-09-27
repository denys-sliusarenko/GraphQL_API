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

        public IQueryable<User> Users()
        {
            return dbContext.Users;
        }
    }
}