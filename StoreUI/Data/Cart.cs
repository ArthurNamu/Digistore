using StoreUI.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StoreUI.Data
{
    public class Cart
    {
        public List<CartItem> Items { get; set; }
        public int Count = 0;
        public void AddItems(CartItem item)
        {
            if (Items.Contains(item) == false)
            {
                Items.Add(item);
            }
        }
        public void RemoveItem(CartItem item)
        {
            if (Items.Contains(item))
            {
                Items.Remove(item);
            }
        }
        public void SaveToDB()
        {

        }
        public async Task<List<CartItem>> RetrieveFromDB()
        {
            return await Task.FromResult(new List<CartItem>());
        }
        public void ClearItems()
        {
            Items.Clear();
            Count = 0;
        }
    }
}
