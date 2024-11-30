using IMS.DTO;
using IMS.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using System.Linq;

namespace IMS.BLL.Services
{
    public class ItemService : IItemService
    {
        private readonly IItemRepository _itemRepository;

        public ItemService(IItemRepository itemRepository)
        {
            _itemRepository = itemRepository;
        }

        public async Task<IEnumerable<Item>> GetAllItemsAsync()
        {
            try
            {
                return await _itemRepository.GetAllItemsAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<Item> GetItemByIdAsync(int id)
        {
            try
            {
                var item = await _itemRepository.GetItemByIdAsync(id);
                return item;
            }
            catch (Exception)
            {
                throw;
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
            catch (Exception)
            {
                throw;
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
            catch (Exception)
            {
                throw;
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
            catch (Exception)
            {
                throw;
            }
        }
    }
}