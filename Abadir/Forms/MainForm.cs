using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Abadir
{
    public partial class MainForm : Form
    {
        public MainForm(string role,string employeeID, string employeeName)
        {
            InitializeComponent();
            //THIS IS TEST CODE
            txtSellerReciptEmployeeID.Text = employeeID;

            txtUsername.Text = employeeName;

            Login login = new Login();
            btnProduct_Click(null, null);
            if (string.Compare(role, "seller")==0)
            {
                btnEmployee.Hide();
                btnProduct.Hide();
                btnSupplier.Hide();
                btnReport.Hide();
                RenameThis.SetPage(3);
                btnSellerInventorySearch_Click(null, null);

                Transaction transaction = new Transaction();
                DataTable dataTable = transaction.GetTransaction(txtSellerReciptEmployeeID.Text);
                dgvSellerInventory.DataSource = dataTable;

            }

            
        }

        private void btnMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnMaximize_Click(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Normal)
                this.WindowState = FormWindowState.Maximized;
            else
                this.WindowState = FormWindowState.Normal;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnProduct_Click(object sender, EventArgs e)
        {
            RenameThis.SetPage(0);
            btnProductClear_Click(sender, e);
        }

        private void btnEmployee_Click(object sender, EventArgs e)
        {
            RenameThis.SetPage(1);
            btnEmployeeClear_Click(sender, e);
        }

        private void btnSupplier_Click(object sender, EventArgs e)
        {
            RenameThis.SetPage(2);
            btnSupplierSearch_Click(sender, e);
        }
        private void btnReport_Click(object sender, EventArgs e)
        {
            RenameThis.SetPage(5);
        }

        private void btnEmployeeAdd_Click(object sender, EventArgs e)
        {
            Employee employee = new Employee();
            employee.employeeID = txtEmployeeID.Text;
            employee.name = txtEmployeeName.Text;
            employee.title = txtEmployeeTitle.Text;
            employee.phoneNumber = txtEmployeePhoneNumber.Text;
            employee.password = txtEmployeePassword.Text;
            employee.status = txtEmployeeStatus.Text;

            employee.SaveEmployee(employee);
            btnEmployeeClear_Click(sender, e);
            btnEmployeeSearch_Click(sender, e);
        }

        private void btnEmployeeSearch_Click(object sender, EventArgs e)
        {
            Employee employee = new Employee();
            DataTable dataTable = employee.GetEmployee(txtEmployeeID.Text, txtEmployeeName.Text);
            dgvEmployee.DataSource = dataTable;
        }

        private void dgvEmployee_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtEmployeeID.Text = Convert.ToString(dgvEmployee.CurrentRow.Cells[0].Value);
            txtEmployeeName.Text = Convert.ToString(dgvEmployee.CurrentRow.Cells[1].Value);
            txtEmployeeTitle.Text = Convert.ToString(dgvEmployee.CurrentRow.Cells[2].Value);
            txtEmployeePhoneNumber.Text = Convert.ToString(dgvEmployee.CurrentRow.Cells[3].Value);
            txtEmployeeStatus.Text = Convert.ToString(dgvEmployee.CurrentRow.Cells[4].Value);
        }

        private void btnEmployeeClear_Click(object sender, EventArgs e)
        {
            txtEmployeeID.Text = "";
            txtEmployeeName.Text = "";
            txtEmployeeTitle.Text = "";
            txtEmployeePhoneNumber.Text = "";
            txtEmployeePassword.Text = "";
            txtEmployeeStatus.Text = "";
            btnEmployeeSearch_Click(sender, e);
        }

        private void btnEmployeeDelete_Click_1(object sender, EventArgs e)
        {
            Employee employee = new Employee();
            employee.DeleteEmployee(txtEmployeeID.Text);
            btnEmployeeClear_Click(sender,e);
            btnEmployeeSearch_Click(sender, e);

        }

        private void btnEmployeeSave_Click(object sender, EventArgs e)
        {
            Employee employee = new Employee();
            employee.employeeID = txtEmployeeID.Text;
            employee.name = txtEmployeeName.Text;
            employee.title = txtEmployeeTitle.Text;
            employee.phoneNumber = txtEmployeePhoneNumber.Text;
            employee.password = txtEmployeePassword.Text;
            employee.status = txtEmployeeStatus.Text;

            employee.UpdateEmployee(employee);
            btnEmployeeClear_Click(sender, e);
            btnEmployeeSearch_Click(sender, e);
        }

        private void btnSupplierAdd_Click(object sender, EventArgs e)
        {
            Supplier supplier = new Supplier();
            supplier.phoneNumber = txtSupplierPhoneNumber.Text;
            supplier.name = txtSupplierName.Text;
            supplier.address = txtSupplierAddress.Text;
            supplier.status = txtSupplierStatus.Text;
            supplier.SaveSupplier(supplier);

            btnSupplierClear_Click(sender, e);
        }

        private void btnSupplierSearch_Click(object sender, EventArgs e)
        {
            Supplier supplier = new Supplier();
            DataTable dataTable = supplier.GetSupplier(txtSupplierName.Text, txtSupplierPhoneNumber.Text);
            dgvSupplier.DataSource = dataTable;
        }

        private void dgvSupplier_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtSupplierPhoneNumber.Text = Convert.ToString(dgvSupplier.CurrentRow.Cells[0].Value);
            txtSupplierName.Text = Convert.ToString(dgvSupplier.CurrentRow.Cells[1].Value);
            txtSupplierAddress.Text = Convert.ToString(dgvSupplier.CurrentRow.Cells[2].Value);
            txtSupplierStatus.Text = Convert.ToString(dgvSupplier.CurrentRow.Cells[3].Value);
        }

        private void btnSupplierClear_Click(object sender, EventArgs e)
        {
            txtSupplierPhoneNumber.Text = "";
            txtSupplierName.Text = "";
            txtSupplierAddress.Text = "";
            txtSupplierStatus.Text = "";

            btnSupplierSearch_Click(sender, e);
        }

        private void btnSupplierSave_Click(object sender, EventArgs e)
        {
            Supplier supplier = new Supplier();
            supplier.phoneNumber = txtSupplierPhoneNumber.Text;
            supplier.name = txtSupplierName.Text;
            supplier.address = txtSupplierAddress.Text;
            supplier.status = txtSupplierStatus.Text;
            supplier.UpdateSupplier(supplier);
            btnSupplierClear_Click(sender, e);
        }

        private void btnSupplierDelete_Click(object sender, EventArgs e)
        {
            Supplier supplier = new Supplier();
            supplier.DeleteSupplier(txtSupplierPhoneNumber.Text);
            btnSupplierClear_Click(sender, e);
        }

        private void btnProductinventory_Click(object sender, EventArgs e)
        {
            RenameThis.SetPage(4);
            btnInventoryClear_Click(sender, e);
            btnInventorySearch_Click(sender, e);
        }

        private void btnInventoryProduct_Click(object sender, EventArgs e)
        {
            RenameThis.SetPage(0);
            btnProductClear_Click(sender, e);
        }

        private void btnProductClear_Click(object sender, EventArgs e)
        {
            txtProductID.Text = "";
            txtProductName.Text = "";
            txtProductDiscription.Text = "";
            txtProductPrice.Text = "";
            btnProductSearch_Click(sender, e);
        }

        private void btnProductAdd_Click(object sender, EventArgs e)
        {
            Product product = new Product();
            product.name = txtProductName.Text;
            product.discription = txtProductDiscription.Text;
            product.price = txtProductPrice.Text;

            product.SaveProduct(product);
            btnProductClear_Click(sender, e);
        }

        private void btnProductSearch_Click(object sender, EventArgs e)
        {
            Product product = new Product();
            DataTable dataTable = product.GetProduct(txtProductName.Text);
            dgvProduct.DataSource = dataTable;
        }

        private void btnProductSave_Click(object sender, EventArgs e)
        {
            Product product = new Product();
            product.productID = Convert.ToInt32( txtProductID.Text);
            product.name = txtProductName.Text;
            product.price = txtProductPrice.Text;
            product.discription = txtProductDiscription.Text;

            product.UpdateProduct(product);
            btnProductClear_Click(sender, e);
        }

        private void dgvProduct_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtProductID.Text = Convert.ToString(dgvProduct.CurrentRow.Cells[0].Value);
            txtProductName.Text = Convert.ToString(dgvProduct.CurrentRow.Cells[1].Value);
            txtProductDiscription.Text = Convert.ToString(dgvProduct.CurrentRow.Cells[2].Value);
            txtProductPrice.Text = Convert.ToString(dgvProduct.CurrentRow.Cells[3].Value);
        }

        private void btnProductDelete_Click(object sender, EventArgs e)
        {
            Product product = new Product();
            product.DeleteProduct(Convert.ToInt32(txtProductID.Text));

            btnProductClear_Click(sender, e);
        }

        private void btnInventoryAdd_Click(object sender, EventArgs e)
        {
            Inventory inventory = new Inventory();
            inventory.productID = Convert.ToInt32(txtInventoryID.Text);
            inventory.importDate = Convert.ToDateTime(txtInventoryImportDate.Text);
            inventory.expireDate =Convert.ToDateTime(txtInventoryExpiryDate.Text);
            inventory.quantity = Convert.ToInt32(txtInventoryQuantity.Text);
            inventory.supplierPhone = txtInventorySupplier.Text;

            inventory.AddInventory(inventory);
            btnInventoryClear_Click(sender, e);
        }

        private void btnInventorySearch_Click(object sender, EventArgs e)
        {
            
           Inventory inventory = new Inventory();
           DataTable dataTable = inventory.GetInventory(txtSellerInventoryName.Text);
            dgvInventory.DataSource = dataTable;

        }

        private void btnInventoryClear_Click(object sender, EventArgs e)
        {
            txtInventoryID.Text = "";
            txtInventoryImportDate.Text = "";
            txtInventoryExpiryDate.Text = "";
            txtInventoryExpiryDate.Text = "";
            txtInventoryQuantity.Text = "";
            txtInventorySupplier.Text = "";
        }

        private void btnInventorySave_Click(object sender, EventArgs e)
        {
            Inventory inventory = new Inventory();
            inventory.productID = Convert.ToInt32(txtInventoryID.Text);
            inventory.importDate = Convert.ToDateTime(txtInventoryImportDate.Text);
            inventory.expireDate = Convert.ToDateTime(txtInventoryExpiryDate.Text);
            inventory.quantity = Convert.ToInt32(txtInventoryQuantity.Text);
            inventory.supplierPhone = txtInventorySupplier.Text;

            inventory.UpdateInventory(inventory);
            txtInventoryImportDate.Text = "";
            txtInventoryExpiryDate.Text = "";
            txtInventoryExpiryDate.Text = "";
            txtInventoryQuantity.Text = "";
            txtInventorySupplier.Text = "";

            btnInventorySearch_Click(sender, e);

        }

        private void dgvInventory_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtInventoryID.Text = Convert.ToString(dgvInventory.CurrentRow.Cells[0].Value);
            txtInventoryImportDate.Text = Convert.ToString(dgvInventory.CurrentRow.Cells[1].Value);
            txtInventoryExpiryDate.Text = Convert.ToString(dgvInventory.CurrentRow.Cells[2].Value);
            txtInventoryQuantity.Text = Convert.ToString(dgvInventory.CurrentRow.Cells[4].Value);
            txtInventorySupplier.Text = Convert.ToString(dgvInventory.CurrentRow.Cells[5].Value);

        }

        private void btnInventoryDelete_Click(object sender, EventArgs e)
        {
            Inventory inventory = new Inventory();
            inventory.productID = Convert.ToInt32(txtInventoryID.Text);
            inventory.importDate = Convert.ToDateTime(txtInventoryImportDate.Text);
            inventory.DeleteInventory(inventory);

            btnEmployeeClear_Click(sender, e);
        }

        private void dgvInventory_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnSellerInventorySearch_Click(object sender, EventArgs e)
        {
            Transaction transaction = new Transaction();
           
            DataTable dataTable = transaction.GetInventoryForSeller(txtSellerInventoryName.Text);
            dgvSellerProduct.DataSource = dataTable;
        }

        private void dgvSellerProduct_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtSellerReciptProductID.Text = Convert.ToString(dgvSellerProduct.CurrentRow.Cells[0].Value);
            txtSellerInventoryProductID.Text = Convert.ToString(dgvSellerProduct.CurrentRow.Cells[0].Value);
            txtSellerInventoryQuantity.Text = Convert.ToString(dgvSellerProduct.CurrentRow.Cells[4].Value);
        }

        private void btnSellerReciptAdd_Click(object sender, EventArgs e)
        {
            if (txtSellerReciptProductID.Text != "" && txtSellerReciptQuantity.Text != "")
            {
                if (txtSellerInventoryProductID.Text == txtSellerReciptProductID.Text)
                {
                    if (Convert.ToInt32(txtSellerReciptQuantity.Text) < Convert.ToInt32(txtSellerInventoryQuantity.Text))
                    {

                        Transaction transaction = new Transaction();
                        transaction.epmployeeID = txtSellerReciptEmployeeID.Text;
                        transaction.productID = Convert.ToInt32(txtSellerReciptProductID.Text);
                        transaction.quantity = Convert.ToInt32(txtSellerReciptQuantity.Text);
                        transaction.AddTransaction(transaction);

                        /*--------------------*/
                        DataTable dataTable = transaction.GetTransaction(txtSellerReciptEmployeeID.Text);
                        dgvSellerInventory.DataSource = dataTable;

                        transaction.DoSell(Convert.ToInt32(txtSellerReciptProductID.Text), Convert.ToInt32(txtSellerReciptQuantity.Text));
                        btnSellerInventorySearch_Click(sender, e);
                        txtSellerReciptProductID.Text = "";
                        txtSellerReciptQuantity.Text = "";
                    }
                    else
                        MessageBox.Show("We dont have that amount of stock in our Inventory");
                }
                else
                    MessageBox.Show("Select Product from the above list");
            }
            else
            {
                MessageBox.Show("Product ID and Quantity can't be Empty");
            }
        }

        private void dgvSellerInventory_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtSellerReciptProductID.Text = Convert.ToString(dgvSellerInventory.CurrentRow.Cells[0].Value);
            txtSellerReciptQuantity.Text = Convert.ToString(dgvSellerInventory.CurrentRow.Cells[1].Value);

        }

        private void btnSellerReciptRemove_Click(object sender, EventArgs e)
        {
            if (txtSellerReciptQuantity.Text != "")
            {
                Transaction transaction = new Transaction();
                transaction.epmployeeID = txtSellerReciptEmployeeID.Text;
                transaction.productID = Convert.ToInt32(txtSellerReciptProductID.Text);
                transaction.quantity = Convert.ToInt32(txtSellerReciptQuantity.Text);

                transaction.DeleteTransaction(transaction);

                DataTable dataTable = transaction.GetTransaction(txtSellerReciptEmployeeID.Text);
                dgvSellerInventory.DataSource = dataTable;

                txtSellerReciptProductID.Text = "";
                txtSellerReciptQuantity.Text = "";
            }
            else
                MessageBox.Show("Select Product to delete from the list");
        }

        private void btnSellerReciptPrint_Click(object sender, EventArgs e)
        {
            Transaction transaction = new Transaction();

            transaction.UpdateTransaction(txtSellerReciptEmployeeID.Text);

            DataTable dataTable = transaction.GetTransaction(txtSellerReciptEmployeeID.Text);
            dgvSellerInventory.DataSource = dataTable;
        }

        private void txtUsername_Click(object sender, EventArgs e)
        {
            PasswordChange passwordChange = new PasswordChange();
            passwordChange.Show();
        }

        private void btnReportSupplier_Click(object sender, EventArgs e)
        {
            CrystalReport.SupplierReport supplierReport = new CrystalReport.SupplierReport();
            supplierReport.SetParameterValue("@name", "");
            crvReport.ReportSource = null;
            crvReport.ReportSource = supplierReport;
        }

        private void btnReportTransaction_Click(object sender, EventArgs e)
        {
            CrystalReport.TransactionReport transactionReport = new CrystalReport.TransactionReport();
            crvReport.ReportSource = null;
            crvReport.ReportSource = transactionReport;
        }

        private void btnReportEmployee_Click(object sender, EventArgs e)
        {
            CrystalReport.EmployeeReport employeeReport = new CrystalReport.EmployeeReport();
            employeeReport.SetParameterValue("@name", "");
            employeeReport.SetParameterValue("@eid", DBNull.Value);

            crvReport.ReportSource = null;
            crvReport.ReportSource = employeeReport;
        }

        private void btnReportInventory_Click(object sender, EventArgs e)
        {
            CrystalReport.InventoryReport inventoryReport = new CrystalReport.InventoryReport();
            inventoryReport.SetParameterValue("@pid", DBNull.Value);

            crvReport.ReportSource = null;
            crvReport.ReportSource = inventoryReport;
        }

        private void btnReportProduct_Click(object sender, EventArgs e)
        {
            CrystalReport.ProductReport productReport = new CrystalReport.ProductReport();
            productReport.SetParameterValue("@pname", "");
            productReport.SetParameterValue("@pid", DBNull.Value);

            crvReport.ReportSource = null;
            crvReport.ReportSource = productReport;
        }
    }

}
