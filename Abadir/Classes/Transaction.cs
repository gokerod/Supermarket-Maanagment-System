using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Data;

namespace Abadir
{
    class Transaction
    {
        public string epmployeeID, status;
        public int productID, quantity;

        public void AddTransaction(Transaction transaction)
        {
            DatabaseLayer database = new DatabaseLayer();
            database.SaveTransaction(transaction);
        }

        public DataTable GetTransaction(string employeeID)
        {
            DatabaseLayer database = new DatabaseLayer();
            DataTable dataTable = database.GetTransaction(employeeID);
            return dataTable;
        }

        public void DeleteTransaction (Transaction transaction)
        {
            DatabaseLayer database = new DatabaseLayer();
            database.DeleteTransaction(transaction);
        }

        public void UpdateTransaction (string employeeID)
        {
            DatabaseLayer database = new DatabaseLayer();
            database.UpdateTransaction(employeeID);
        }

        public DataTable GetInventoryForSeller(string productName)
        {
            DatabaseLayer database = new DatabaseLayer();
            DataTable dataTable = database.GetInventoryForSeller(productName);
            return dataTable;
        }

        public void DoSell (int productID, int quantity)
        {
            DatabaseLayer database = new DatabaseLayer();
            database.DoSell(productID, quantity);
        }
    }
}
