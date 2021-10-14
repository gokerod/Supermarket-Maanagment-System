using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Data;

namespace Abadir
{
    class Inventory
    {
        public int productID,quantity;
        public DateTime importDate, expireDate;
        public string supplierPhone;

        public void AddInventory(Inventory inventory)
        {
            DatabaseLayer database = new DatabaseLayer();
            database.SaveInventory(inventory);
        }

        public DataTable GetInventory(string productID)
        {
            DatabaseLayer database = new DatabaseLayer();
            DataTable dataTable = database.GetInventory(productID);
            return dataTable;
        }

        public void UpdateInventory(Inventory inventory)
        {
            DatabaseLayer database = new DatabaseLayer();
            database.UpdateInventory(inventory);
        }

        public void DeleteInventory(Inventory inventory)
        {
            DatabaseLayer database = new DatabaseLayer();
            database.DeleteInventory(inventory);
        }
    }
}
