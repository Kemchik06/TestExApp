using System.Collections.Generic;
using System.Threading.Tasks;
using TestExApp.Models;

namespace TestExApp.Services
{
    public interface IItemService
    {
        Task SaveItems(List<Item> items);

        Task<List<Item>> GetAll();
    }
}
