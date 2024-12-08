using IMS.DTO;
using IMS.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using Microsoft.Extensions.Logging;

namespace IMS.BLL.Services
{
    public class ItemService : IItemService
    {
        private readonly IItemRepository _itemRepository;
        private readonly ILogger<ItemService> _logger;

        public ItemService(IItemRepository itemRepository, ILogger<ItemService> logger)
        {
            _itemRepository = itemRepository;
            _logger = logger;
        }

        public async Task<IEnumerable<Item>> GetAllItemsAsync()
        {
            try
            {
                return await _itemRepository.GetAllItemsAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while getting all items.");
                throw new InvalidOperationException("Error occurred while getting all items.", ex);
            }
        }

        public async Task<Item> GetItemByIdAsync(int id)
        {
            try
            {
                var item = await _itemRepository.GetItemByIdAsync(id);
                return item;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while getting item by ID: {ItemID}", id);
                throw new InvalidOperationException($"Error occurred while getting item by ID: {id}", ex);
            }
        }

        public async Task AddItemAsync(Item item)
        {
            if (item == null)
            {
                throw new ArgumentNullException(nameof(item), "Item is null.");
            }

            try
            {
                if (await _itemRepository.ItemNameExistsAsync(item.ItemName))
                {
                    throw new InvalidOperationException($"Item with name {item.ItemName} already exists.");
                }

                await _itemRepository.AddItemAsync(item);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while adding item.");
                throw new InvalidOperationException("Error occurred while adding item.", ex);
            }
        }

        public async Task UpdateItemAsync(Item item)
        {
            if (item == null)
            {
                throw new ArgumentNullException(nameof(item), "Item is null.");
            }

            try
            {
                await _itemRepository.UpdateItemAsync(item);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while updating item.");
                throw new InvalidOperationException("Error occurred while updating item.", ex);
            }
        }

        public async Task DeleteItemAsync(int id)
        {
            try
            {
                var item = await _itemRepository.GetItemByIdAsync(id);
                if (item == null)
                {
                    return;
                }
                await _itemRepository.DeleteItemAsync(id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while deleting item with ID: {Id}", id);
                throw new InvalidOperationException($"Error occurred while deleting item with ID: {id}", ex);
            }
        }

        public async Task<bool> HasRelatedStocksAsync(int ItemID)
        {
            try
            {
                return await _itemRepository.HasRelatedStocksAsync(ItemID);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while checking related stocks for item ID: {ItemID}", ItemID);
                throw new InvalidOperationException($"Error occurred while checking related stocks for item ID: {ItemID}", ex);
            }
        }

        public async Task DeleteRelatedStocksAsync(int ItemID)
        {
            try
            {
                await _itemRepository.DeleteRelatedStocksAsync(ItemID);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while deleting related stocks for item ID: {ItemID}", ItemID);
                throw new InvalidOperationException($"Error occurred while deleting related stocks for item ID: {ItemID}", ex);
            }
        }
    }
}
