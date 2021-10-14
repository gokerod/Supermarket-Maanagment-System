using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data;

namespace Abadir
{
    class DatabaseLayer
    {
        string conStr = "server = ESYARIB\\MSSQLSERVER01;database=Abadir;uid=AbadirProject;pwd=123;";

        public string GetRole(string employeeID, string password)
        {
            SqlConnection con = new SqlConnection(conStr);
            con.Open();
            SqlCommand cmd = new SqlCommand("GetRole", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@eid", employeeID);
            cmd.Parameters.AddWithValue("@password", password);
            object obj = cmd.ExecuteScalar();
            if (obj != null)
                return obj.ToString();
            else
                return "No Employee";

        }
        public string GetPassword(string employeeID)
        {
            SqlConnection con = new SqlConnection(conStr);
            con.Open();
            SqlCommand cmd = new SqlCommand("GetPassword", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@eid", employeeID);
            object obj = cmd.ExecuteScalar();
            if (obj != null)
                return obj.ToString();
            else
                return "Incorrect Password" +
                    "";

        }
        public string GetName(string employeeID)
        {
            SqlConnection con = new SqlConnection(conStr);
            con.Open();
            SqlCommand cmd = new SqlCommand("GetName", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@eid", employeeID);
            object obj = cmd.ExecuteScalar();
            if (obj != null)
                return obj.ToString();
            else
                return "No Employee";

        }

        public void SaveEmployee(Employee employee)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("dbo.InsertIntoEmployee", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@eid", employee.employeeID);
                    cmd.Parameters.AddWithValue("@name", employee.name);
                    cmd.Parameters.AddWithValue("@title", employee.title);
                    cmd.Parameters.AddWithValue("@phoneNumber", employee.phoneNumber);
                    cmd.Parameters.AddWithValue("@password", employee.password);
                    cmd.Parameters.AddWithValue("@status", employee.status);

                    int row = cmd.ExecuteNonQuery();
                    con.Close();
                    if (row > 0)
                        MessageBox.Show("Save succesfully !");
                    else
                        MessageBox.Show("Save unsuccessful");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public DataTable GetEmployee(string id, string name)
        {
            using (SqlConnection con = new SqlConnection(conStr))
            {
                con.Open();
                using (SqlDataAdapter dataAdapter = new SqlDataAdapter())
                {
                    dataAdapter.SelectCommand = new SqlCommand("SelectEmployee", con);
                    dataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                    if (id == "" && name != "")
                        id = "!!!!!!";
                    if (id != "" && name == "")
                        name = "!!!!!!";
                        dataAdapter.SelectCommand.Parameters.AddWithValue("@name", name);
                        dataAdapter.SelectCommand.Parameters.AddWithValue("@eid", id);
                    
                    DataSet dataSet= new DataSet();
                    dataAdapter.Fill(dataSet, "EmployeeData");
                    DataTable dataTable = dataSet.Tables["EmployeeData"];
                    return dataTable;
                }
            }
        }
        public void DeleteEmployee(string employeeID)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("DeleteEmployee", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@eid",employeeID);

                    int row = cmd.ExecuteNonQuery();
                    con.Close();
                    if (row > 0)
                        MessageBox.Show("Deleted succesfully !");
                    else
                        MessageBox.Show("Delete unsuccessful");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public void UpdateEmployee(Employee employee)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("UpdateEmployee", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@eid", employee.employeeID);
                    cmd.Parameters.AddWithValue("@name", employee.name);
                    cmd.Parameters.AddWithValue("@title", employee.title);
                    cmd.Parameters.AddWithValue("@phoneNumber", employee.phoneNumber);
                    cmd.Parameters.AddWithValue("@status", employee.status);

                    int row = cmd.ExecuteNonQuery();
                    con.Close();
                    if (row > 0)
                        MessageBox.Show("Update succesfully !");
                    else
                        MessageBox.Show("Update unsuccessful");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public void UpdateEmployeePassword(string employeeID, string newPassword)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("UpdateEmployeePassword", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@eid", employeeID);
                    cmd.Parameters.AddWithValue("@password", newPassword);
                    int row = cmd.ExecuteNonQuery();
                    con.Close();
                    if (row > 0)
                        MessageBox.Show("Password Changed Succesfully !");
                    else
                        MessageBox.Show("Password was not Changed");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void SaveSupplier(Supplier supplier)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("InsertIntoSupplier", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@phonenumber", supplier.phoneNumber);
                    cmd.Parameters.AddWithValue("@name", supplier.name);
                    cmd.Parameters.AddWithValue("@address", supplier.address);
                    cmd.Parameters.AddWithValue("@status", supplier.status);

                    int row = cmd.ExecuteNonQuery();
                    con.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public DataTable GetSupplier(string name, string phoneNumber)
        {
            using (SqlConnection con = new SqlConnection(conStr))
            {
                con.Open();
                using (SqlDataAdapter dataAdapter = new SqlDataAdapter())
                {
                    dataAdapter.SelectCommand = new SqlCommand("SelectSupplier", con);
                    dataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                    if (name == "" && phoneNumber != "")
                        name = "!!!!!!";
                    if (name != "" && phoneNumber == "")
                        phoneNumber = "!!!!!!";
                    dataAdapter.SelectCommand.Parameters.AddWithValue("@name", name);
                    dataAdapter.SelectCommand.Parameters.AddWithValue("@phoneNumber", phoneNumber);

                    DataSet dataSet = new DataSet();
                    dataAdapter.Fill(dataSet, "SupplierData");
                    DataTable dataTable = dataSet.Tables["SupplierData" +
                        ""];
                    return dataTable;
                }
            }
        }
        public void UpdateSupplier(Supplier supplier)
        
        {
            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("UpdateSupplier", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@phonenumber", supplier.phoneNumber);
                    cmd.Parameters.AddWithValue("@name", supplier.name);
                    cmd.Parameters.AddWithValue("@address", supplier.address);
                    cmd.Parameters.AddWithValue("@status", supplier.status);


                    int row = cmd.ExecuteNonQuery();
                    con.Close();
                    if (row > 0)
                        MessageBox.Show("Update succesfully !");
                    else
                        MessageBox.Show("Update unsuccessful");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public void DeleteSupplier(string phoneNumber)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("DeleteSupplier", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@phoneNumber", phoneNumber);

                    int row = cmd.ExecuteNonQuery();
                    con.Close();
                    if (row > 0)
                        MessageBox.Show("Deleted succesfully !");
                    else
                        MessageBox.Show("Delete unsuccessful");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void SaveProduct(Product product)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("InsertIntoProductList", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@pname", product.name);
                    cmd.Parameters.AddWithValue("@discription", product.discription);
                    cmd.Parameters.AddWithValue("@Price", product.price);

                    int row = cmd.ExecuteNonQuery();
                    con.Close();

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public DataTable GetProduct(string name)
        {
            using (SqlConnection con = new SqlConnection(conStr))
            {
                con.Open();
                using (SqlDataAdapter dataAdapter = new SqlDataAdapter())
                {
                    dataAdapter.SelectCommand = new SqlCommand("SelectProductListOutOfStock", con);
                    dataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                    dataAdapter.SelectCommand.Parameters.AddWithValue("@pname", name);
                    DataSet dataSet = new DataSet();
                    dataAdapter.Fill(dataSet, "ProductData");
                    DataTable dataTable = dataSet.Tables["ProductData" +""];
                    return dataTable;
                }
            }
        }
        public void UpdateProduct(Product product)

        {
            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("UpdateProductList", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@pid", product.productID);
                    cmd.Parameters.AddWithValue("@pname", product.name);
                    cmd.Parameters.AddWithValue("@discription", product.discription);
                    cmd.Parameters.AddWithValue("@Price", product.price);


                    int row = cmd.ExecuteNonQuery();
                    con.Close();
                    if (row > 0)
                        MessageBox.Show("Update succesfully !");
                    else
                        MessageBox.Show("Update unsuccessful");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public void DeleteProduct(int productID)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("DeleteProductList", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@pid", productID);

                    int row = cmd.ExecuteNonQuery();
                    con.Close();
                    if (row > 0)
                        MessageBox.Show("Deleted succesfully !");
                    else
                        MessageBox.Show("Delete unsuccessful");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void SaveInventory(Inventory inventory)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("InsertIntoProduct", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@pid", inventory.productID);
                    cmd.Parameters.AddWithValue("@importeddate", inventory.importDate);
                    cmd.Parameters.AddWithValue("@expirydate", inventory.expireDate);
                    cmd.Parameters.AddWithValue("@quantity", inventory.quantity);
                    cmd.Parameters.AddWithValue("@supplierphone", inventory.supplierPhone);

                    int row = cmd.ExecuteNonQuery();
                    con.Close();

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public DataTable GetInventory(string productID)
        {
            using (SqlConnection con = new SqlConnection(conStr))
            {
                con.Open();
                using (SqlDataAdapter dataAdapter = new SqlDataAdapter())
                {
                    dataAdapter.SelectCommand = new SqlCommand("SelectProduct", con);
                    dataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                    if(productID == "")
                        dataAdapter.SelectCommand.Parameters.AddWithValue("@pid", DBNull.Value);
                    else
                    dataAdapter.SelectCommand.Parameters.AddWithValue("@pid", productID);
                    DataSet dataSet = new DataSet();
                    dataAdapter.Fill(dataSet, "InventoryData");
                    DataTable dataTable = dataSet.Tables["InventoryData" + ""];
                    return dataTable;
                }
            }
        }
        public DataTable GetInventoryForSeller(string name)
        {
            using (SqlConnection con = new SqlConnection(conStr))
            {
                con.Open();
                using (SqlDataAdapter dataAdapter = new SqlDataAdapter())
                {
                    dataAdapter.SelectCommand = new SqlCommand("SelectProductList", con);
                    dataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                    dataAdapter.SelectCommand.Parameters.AddWithValue("@pname", name);
                    DataSet dataSet = new DataSet();
                    dataAdapter.Fill(dataSet, "ProductData");
                    DataTable dataTable = dataSet.Tables["ProductData" + ""];
                    return dataTable;
                }
            }
        }
        public void UpdateInventory(Inventory inventory)

        {
            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("UpdateProduct", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@pid", inventory.productID);
                    cmd.Parameters.AddWithValue("@importeddate", inventory.importDate);
                    cmd.Parameters.AddWithValue("@expirydate", inventory.expireDate);
                    cmd.Parameters.AddWithValue("@quantity", inventory.quantity);
                    cmd.Parameters.AddWithValue("@supplierphone", inventory.supplierPhone);


                    int row = cmd.ExecuteNonQuery();
                    con.Close();
                    if (row > 0)
                        MessageBox.Show("Update succesfully !");
                    else
                        MessageBox.Show("Update unsuccessful");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public void DeleteInventory(Inventory inventory)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("DeleteProduct", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@pid", inventory.productID);
                    cmd.Parameters.AddWithValue("@importeddate", inventory.importDate);
                    int row = cmd.ExecuteNonQuery();
                    con.Close();
                    if (row > 0)
                        MessageBox.Show("Deleted succesfully !");
                    else
                        MessageBox.Show("Delete unsuccessful");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void SaveTransaction(Transaction transaction)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("InsertIntoTransaction", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@eid", transaction.epmployeeID);
                    cmd.Parameters.AddWithValue("@pid", transaction.productID);
                    cmd.Parameters.AddWithValue("@qunatity", transaction.quantity);
                    int row = cmd.ExecuteNonQuery();
                    con.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public DataTable GetTransaction(string employeeID)
        {
            using (SqlConnection con = new SqlConnection(conStr))
            {
                con.Open();
                using (SqlDataAdapter dataAdapter = new SqlDataAdapter())
                {
                    dataAdapter.SelectCommand = new SqlCommand("SelectTransaction", con);
                    dataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                    dataAdapter.SelectCommand.Parameters.AddWithValue("@eid", employeeID);
                    DataSet dataSet = new DataSet();
                    dataAdapter.Fill(dataSet, "TransactionData");
                    DataTable dataTable = dataSet.Tables["TransactionData" + ""];
                    return dataTable;
                }
            }
        }
        public void DeleteTransaction(Transaction transaction)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("DeleteTansaction", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@eid", transaction.epmployeeID);
                    cmd.Parameters.AddWithValue("@pid", transaction.productID);
                    cmd.Parameters.AddWithValue("@quantity", transaction.quantity);
                    int row = cmd.ExecuteNonQuery();
                    con.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public void UpdateTransaction(string employeeID)

        {
            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("UpdateTransaction", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@eid", employeeID);
                    int row = cmd.ExecuteNonQuery();
                    con.Close();
                    if (row > 0)
                        MessageBox.Show("Sold succesfully !");
                    else
                        MessageBox.Show("There is something wrong with the tranasaction");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public void DoSell(int productID, int quantitiy)

        {
            try
            {
                using (SqlConnection con = new SqlConnection(conStr))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("DoSell", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@pid", productID);
                    cmd.Parameters.AddWithValue("@quantity", quantitiy);
                    int row = cmd.ExecuteNonQuery();
                    con.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }

}
