using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week10
{
    public class InventoryItem
    {
        public int Item {  get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }

        public InventoryItem() { }
        public InventoryItem(int item, string description, decimal price)
        {
            this.Item = item;
            this.Description = description;
            this.Price = price;
            
        }

        public override string ToString()
        {
            return $"Item No: {Item}, Description: {Description}, Price: ${Price}";
        }
    }
}
