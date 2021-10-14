using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Data;

namespace Abadir
{
    class Employee
    {
        public string employeeID, name, title, phoneNumber, password, status;

        public void SaveEmployee(Employee employee)
        {
            DatabaseLayer database = new DatabaseLayer();
            database.SaveEmployee(employee);
        }
        public DataTable GetEmployee(string id, string name)
        {
            DatabaseLayer database = new DatabaseLayer();
            DataTable dataTable = database.GetEmployee(id, name);
            return dataTable;
        }
        public void DeleteEmployee(string employeeID)
        {
            DatabaseLayer database = new DatabaseLayer();
            database.DeleteEmployee(employeeID);
        }
        public void UpdateEmployee(Employee employee)
        {
            DatabaseLayer database = new DatabaseLayer();
            database.UpdateEmployee(employee);
        }
    }
}
