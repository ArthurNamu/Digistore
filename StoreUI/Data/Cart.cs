using StoreUI.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StoreUI.Data
{
    public class Cart
    {
        public List<CartItemModel> Items { get; set; }
        public int Count = 0;
        public void AddItems(CartItemModel item)
        {
            if (Items.Contains(item) == false)
            {
                Items.Add(item);
            }
        }
        public void RemoveItem(CartItemModel item)
        {
            if (Items.Contains(item))
            {
                Items.Remove(item);
            }
        }
        public void SaveToDB()
        {

        }
        public async Task<List<CartItemModel>> RetrieveFromDB()
        {
            return await Task.FromResult(new List<CartItemModel>());
        }
        public void ClearItems()
        {
            Items.Clear();
            Count = 0;
        }
        public async Task<bool> EmailOrderAsync()
        {
            return await (Task.FromResult(true));
        } 
    }
}
