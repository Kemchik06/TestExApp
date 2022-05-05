using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestExApp.Repository
{
    public interface IRepository
    {
        IQueryable<T> SelectAll<T>() where T : class;
        Task SaveListAsync<T>(List<T> list) where T : class;
        Task DeleteAll<T>() where T : class;
        Task<int> GetItemsCount<T>() where T : class;
    }
}
