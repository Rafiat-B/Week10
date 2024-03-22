using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Week10
{
    public static class InventoryDB
    {
        private static readonly string Path = @"C:\Users\Admin\Desktop\JUZT-OYIN\APP.DEV.C#\Week10\grocery_inventory_items.txt";
        private const char Delimiter = '|';


        public static List<InventoryItem> GetItems()
        {
            List<InventoryItem> items = new List<InventoryItem>();


            using (StreamReader textIn = new StreamReader(new FileStream(Path, FileMode.OpenOrCreate, FileAccess.Read)))
            {
                string row;
                while ((row = textIn.ReadLine()) != null)
                {
                    string[] columns = row.Split(Delimiter);


                    if (columns.Length == 3)
                    {
                        InventoryItem item = new InventoryItem
                        {
                            Item  = Convert.ToInt32(columns[0]),
                            Description = columns[1],
                            Price = Convert.ToDecimal(columns[2])
                        };
                        items.Add(item);
                    }
                }
            }
            return items;
        }


        public static void SaveItems(List<InventoryItem> items)
        {
            using (StreamWriter textOut = new StreamWriter(new FileStream(Path, FileMode.Create, FileAccess.Write)))
            {
                foreach (InventoryItem item in items)
                {
                    textOut.Write(item.Item.ToString() + Delimiter);
                    textOut.Write(item.Description + Delimiter);
                    textOut.WriteLine(item.Price);
                }
            }
        }
    }
}



    