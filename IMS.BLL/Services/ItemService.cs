using IMS.Common.Models;
using IMS.Common.Entities;
using IMS.Interfaces.Repositories;
using IMS.Interfaces.Services;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System;

namespace IMS.BLL.Services
{
    public class ItemService : IItemService
    {
        private readonly IItemRepository _itemRepository;

        public ItemService(IItemRepository itemRepository)
        {
            _itemRepository = itemRepository;
        }

        public async Task<IEnumerable<ItemModel>> GetAllItemsAsync()
        {
            var items = await _itemRepository.GetAllItemsAsync();
            return items.Select(ToItemModel);
        }

        public async Task<ItemModel> GetItemByIdAsync(int id)
        {
            var item = await _itemRepository.GetItemByIdAsync(id);
            return item == null ? null : ToItemModel(item);
        }

        public async Task AddItemAsync(ItemModel itemModel)
        {
            if (itemModel == null)
            {
                throw new ArgumentNullException(nameof(itemModel), "Item is null.");
            }

            if (await _itemRepository.ItemNameExistsAsync(itemModel.ItemName))
            {
                throw new InvalidOperationException($"Item with name {itemModel.ItemName} already exists.");
            }

            var item = ToItemEntity(itemModel);
            await _itemRepository.AddItemAsync(item);
        }

        public async Task UpdateItemAsync(ItemModel itemModel)
        {
            if (itemModel == null)
            {
                throw new ArgumentNullException(nameof(itemModel), "Item is null.");
            }

            var item = ToItemEntity(itemModel);
            await _itemRepository.UpdateItemAsync(item);
        }

        public async Task DeleteItemAsync(int id)
        {
            var item = await _itemRepository.GetItemByIdAsync(id);
            if (item == null)
            {
                return;
            }
            await _itemRepository.DeleteItemAsync(id);
        }

        public async Task<bool> HasRelatedStocksAsync(int itemId)
        {
            return await _itemRepository.HasRelatedStocksAsync(itemId);
        }

        public async Task DeleteRelatedStocksAsync(int itemId)
        {
            await _itemRepository.DeleteRelatedStocksAsync(itemId);
        }

        private ItemModel ToItemModel(Item item)
        {
            return new ItemModel
            {
                ItemID = item.ItemID,
                ItemName = item.ItemName,
                Unit = item.Unit,
                Price = item.Price
            };
        }

        private Item ToItemEntity(ItemModel itemModel)
        {
            return new Item
            {
                ItemID = itemModel.ItemID,
                ItemName = itemModel.ItemName,
                Unit = itemModel.Unit,
                Price = itemModel.Price
            };
        }
    }
}