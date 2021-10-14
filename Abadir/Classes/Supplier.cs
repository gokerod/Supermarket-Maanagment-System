using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Data;

namespace Abadir
{
    class Supplier
    {
        public string phoneNumber, name, address, status;

        public void SaveSupplier(Supplier supplier)
        {
            DatabaseLayer database = new DatabaseLayer();
            database.SaveSupplier(supplier);
        }
        public DataTable GetSupplier(string name, string phoneNumber)
        {
            DatabaseLayer database = new DatabaseLayer();
            DataTable dataTable = database.GetSupplier(name, phoneNumber);
            return dataTable;
        }

        public void UpdateSupplier(Supplier supplier)
        {
            DatabaseLayer database = new DatabaseLayer();
            database.UpdateSupplier(supplier);
        }

        public void DeleteSupplier(string phoneNumber)
        {
            DatabaseLayer database = new DatabaseLayer();
            database.DeleteSupplier(phoneNumber);
        }
    }
}
