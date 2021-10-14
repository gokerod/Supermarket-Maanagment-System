using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Data;

namespace Abadir
{
    class Product
    {
        public int productID;
        public string name, discription, price;

        public void SaveProduct(Product product)
        {
            DatabaseLayer database = new DatabaseLayer();
            database.SaveProduct(product);
        }

        public DataTable GetProduct(string name)
        {
            DatabaseLayer database = new DatabaseLayer();
            DataTable dataTable = database.GetProduct(name);
            return dataTable;
        }

        public void UpdateProduct(Product product)
        {
            DatabaseLayer database = new DatabaseLayer();
            database.UpdateProduct(product);
        }

        public void DeleteProduct(int productID)
        {
            DatabaseLayer database = new DatabaseLayer();
            database.DeleteProduct(productID);
        }
    }
}
