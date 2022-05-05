using System.Collections.Generic;
using System.Threading.Tasks;
using TestExApp.Models;
using TestExApp.Models.Dtos;

namespace TestExApp.Services
{
    public interface IItemService
    {
        Task SaveItems(List<Item> items);

        Task<ItemDto> GetAll(int pageSize, int pageNumber);
    }
}
