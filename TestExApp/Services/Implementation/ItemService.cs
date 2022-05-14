using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
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
        private ILogger<ItemService> _logger;

        public ItemService(IRepository repository, ILogger<ItemService> logger)
        {
            _repository = repository;
            _logger = logger;
        }

        public async Task<ItemDto> GetAll(int pageSize, int pageNumber)
        {
            try
            {
                var itemsCount = await _repository.GetItemsCount<Item>();
                var items = await _repository.SelectAll<Item>()
                    .Skip(pageSize * (pageNumber - 1))
                    .Take(pageSize)
                    .ToListAsync();

                return new ItemDto
                {
                    Items = items,
                    ItemsCount = itemsCount
                };
            }
            catch (Exception ex)
            {
                _logger.LogError($"Ошибка при получении списка объектов: {ex.Message }");
                return new ItemDto();
            }
        }

        public async Task SaveItems(List<Item> items)
        {
            try
            {
                await _repository.DeleteAll<Item>();

                await _repository.SaveListAsync<Item>(items);
            }
            catch(Exception ex)
            {
                _logger.LogError($"Ошибка при сохранении объектов: {ex.Message }");
            }
        }
    }
}
