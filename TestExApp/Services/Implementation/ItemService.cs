using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestExApp.Models;
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

        public async Task<List<Item>> GetAll()
        {
            return await _repository.SelectAll<Item>();
        }

        public async Task SaveItems(List<Item> items)
        {
            await _repository.DeleteAll<Item>();

            await _repository.SaveListAsync<Item>(items);
        }
    }
}
