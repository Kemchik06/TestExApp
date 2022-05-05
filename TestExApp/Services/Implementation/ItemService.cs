using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestExApp.Models;
using TestExApp.Models.Dtos;
using TestExApp.Repository;

namespace TestExApp.Services.Implementation
{
    public class ItemService : IItemService
    {
        private readonly IRepository _repository;
        public ItemService(IRepository repository)
        {
            _repository = repository;
        }

        public async Task<ItemDto> GetAll(int pageSize, int pageNumber)
        {
            var itemsCount = await _repository.GetItemsCount<Item>();
            var items = await _repository.SelectAll<Item>()
                .Skip(pageSize * (pageNumber-1))
                .Take(5)
                .ToListAsync();

            return new ItemDto
            {
                Items = items,
                ItemsCount = itemsCount
            };
        }

        public async Task SaveItems(List<Item> items)
        {
            await _repository.DeleteAll<Item>();

            await _repository.SaveListAsync<Item>(items);
        }
    }
}
