using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestExApp.Repository.Implemetation
{
    public class Repository<TDbContext> : IRepository where TDbContext : DbContext
    {
        protected TDbContext dbContext;

        public Repository(TDbContext context)
        {
            dbContext = context;
        }

        public async Task SaveListAsync<T>(List<T> list) where T : class
        {
            foreach(var entity in list)
            {
                dbContext.Set<T>().Add(entity);
            }

            await dbContext.SaveChangesAsync();
        }

        public async Task<List<T>> SelectAll<T>() where T : class
        {
            return await dbContext.Set<T>().ToListAsync();
        }

        public async Task DeleteAll<T>() where T : class
        {
            dbContext.Set<T>().RemoveRange(dbContext.Set<T>());
           await dbContext.SaveChangesAsync();
        }
    }
}
