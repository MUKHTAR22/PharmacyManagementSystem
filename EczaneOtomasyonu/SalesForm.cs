using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;
using System.Windows.Forms;

namespace EczaneOtomasyonu
{
    public partial class SalesForm : Form
    {
        public SalesForm()
        {
            InitializeComponent();
        }

        private void SalesForm_Load(object sender, EventArgs e)
        {
            LoadMedicinesIntoComboBox();
        }

        private string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;Initial Catalog=PharmacyDB;Integrated Security=True;";


        private void LoadMedicinesIntoComboBox()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    string query = "SELECT MedicineID, Name FROM Medicines WHERE Stock > 0"; // Load only medicines in stock
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        conn.Open();
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            var medicineList = new List<KeyValuePair<int, string>>();
                            while (reader.Read())
                            {
                                medicineList.Add(new KeyValuePair<int, string>(
                                    reader.GetInt32(0), // MedicineID
                                    reader.GetString(1) // Name
                                ));
                            }

                            cmbMedicines.DataSource = new BindingSource(medicineList, null);
                            cmbMedicines.DisplayMember = "Value"; // Display medicine name
                            cmbMedicines.ValueMember = "Key"; // Use MedicineID as the value
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while loading medicines: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private List<CartItem> cart = new List<CartItem>();

        private void btnAddToCart_Click(object sender, EventArgs e)
        {
            try
            {
                // Validate medicine selection
                int medicineId;
                int quantity;
                
                    if (cmbMedicines.SelectedValue == null || !int.TryParse(cmbMedicines.SelectedValue.ToString(), out medicineId))
                {
                    MessageBox.Show("Please select a valid medicine.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Get the selected medicine name
                string medicineName = ((KeyValuePair<int, string>)cmbMedicines.SelectedItem).Value;

                // Validate the quantity input
                if (!int.TryParse(txtQuantity.Text, out quantity) || quantity <= 0)
                {
                    MessageBox.Show("Please enter a valid quantity greater than 0.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    // Query to check stock and price
                    string query = "SELECT Stock, Price FROM Medicines WHERE MedicineID = @MedicineID";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@MedicineID", medicineId);
                        conn.Open();
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                int stock = reader.GetInt32(0);
                                decimal price = reader.GetDecimal(1);

                                // Validate stock availability
                                if (quantity > stock)
                                {
                                    MessageBox.Show("Not enough stock available. Please reduce the quantity.", "Stock Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    return;
                                }

                                // Check if the medicine is already in the cart
                                CartItem existingItem = cart.FirstOrDefault(item => item.MedicineID == medicineId);
                                if (existingItem != null)
                                {
                                    // Update the quantity of the existing item
                                    existingItem.Quantity += quantity;
                                }
                                else
                                {
                                    // Add a new item to the cart
                                    cart.Add(new CartItem
                                    {
                                        MedicineID = medicineId,
                                        MedicineName = medicineName,
                                        Quantity = quantity,
                                        Price = price
                                    });
                                }

                                // Update the cart view
                                UpdateCartView();
                                MessageBox.Show("Item added to cart successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            else
                            {
                                MessageBox.Show("The selected medicine could not be found in the database.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void UpdateCartView()
        {
            dgvCart.DataSource = null; // Clear existing data source
            dgvCart.DataSource = cart; // Bind the updated cart list

            // Calculate and display the total price
            lblTotalAmount.Text = $"Total: {cart.Sum(item => item.TotalPrice):C2}";
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            var mainMenuForm = new mainMenu();
            mainMenuForm.Show();

            this.Hide();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void cmbMedicines_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void txtCustomerID_Leave(object sender, EventArgs e)
        {
           
        }


        private void btnRemoveFromCart_Click(object sender, EventArgs e)
        {
            try
            {
                // Check if a row is selected in the DataGridView
                if (dgvCart.SelectedRows.Count > 0)
                {
                    // Get the index of the selected row
                    int selectedIndex = dgvCart.SelectedRows[0].Index;

                    // Remove the item from the cart list at the selected index
                    cart.RemoveAt(selectedIndex);

                    // Update the cart view
                    UpdateCartView();

                    MessageBox.Show("Item removed from cart successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Please select an item to remove from the cart.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnFinalizeSale_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    using (SqlTransaction transaction = conn.BeginTransaction())
                    {
                        try
                        {
                            int? customerID = null;
                            string customerName = txtCustomerName.Text.Trim();
                            string customerPhone = txtCustomerPhone.Text.Trim();
                            string customerEmail = txtCustomerEmail.Text.Trim();
                            string customerAddress = txtCustomerAddress.Text.Trim();

                            // Validate inputs
                            if (string.IsNullOrEmpty(customerName) || string.IsNullOrEmpty(customerPhone) ||
                                string.IsNullOrEmpty(customerEmail) || string.IsNullOrEmpty(customerAddress))
                            {
                                MessageBox.Show("All customer details (Name, Phone, Email, Address) are required.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return;
                            }

                            if (cart.Count == 0)
                            {
                                MessageBox.Show("Cart is empty. Please add items to finalize the sale.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return;
                            }

                            // Check or insert customer
                            int parsedCustomerID;
                            if (!string.IsNullOrEmpty(txtCustomerID.Text.Trim()) && int.TryParse(txtCustomerID.Text.Trim(), out parsedCustomerID))
                            {
                                customerID = parsedCustomerID;
                                string checkCustomerQuery = "SELECT COUNT(*) FROM Customers WHERE CustomerID = @CustomerID";
                                using (SqlCommand cmd = new SqlCommand(checkCustomerQuery, conn, transaction))
                                {
                                    cmd.Parameters.AddWithValue("@CustomerID", customerID);
                                    int customerExists = (int)cmd.ExecuteScalar();

                                    if (customerExists == 0)
                                    {
                                        string insertCustomerQuery = @"INSERT INTO Customers (CustomerID, Name, Phone, Email, Address)
                                                               VALUES (@CustomerID, @CustomerName, @CustomerPhone, @CustomerEmail, @CustomerAddress)";
                                        using (SqlCommand insertCmd = new SqlCommand(insertCustomerQuery, conn, transaction))
                                        {
                                            insertCmd.Parameters.AddWithValue("@CustomerID", customerID);
                                            insertCmd.Parameters.AddWithValue("@CustomerName", customerName);
                                            insertCmd.Parameters.AddWithValue("@CustomerPhone", customerPhone);
                                            insertCmd.Parameters.AddWithValue("@CustomerEmail", customerEmail);
                                            insertCmd.Parameters.AddWithValue("@CustomerAddress", customerAddress);
                                            insertCmd.ExecuteNonQuery();
                                        }
                                    }
                                }
                            }
                            else
                            {
                                string insertCustomerQuery = @"INSERT INTO Customers (Name, Phone, Email, Address)
                                                       OUTPUT INSERTED.CustomerID
                                                       VALUES (@CustomerName, @CustomerPhone, @CustomerEmail, @CustomerAddress)";
                                using (SqlCommand insertCmd = new SqlCommand(insertCustomerQuery, conn, transaction))
                                {
                                    insertCmd.Parameters.AddWithValue("@CustomerName", customerName);
                                    insertCmd.Parameters.AddWithValue("@CustomerPhone", customerPhone);
                                    insertCmd.Parameters.AddWithValue("@CustomerEmail", customerEmail);
                                    insertCmd.Parameters.AddWithValue("@CustomerAddress", customerAddress);
                                    customerID = (int)insertCmd.ExecuteScalar();
                                }
                            }

                            // Call AddSale stored procedure
                            int saleID;
                            using (SqlCommand cmd = new SqlCommand("AddSale", conn, transaction))
                            {
                                cmd.CommandType = CommandType.StoredProcedure;
                                cmd.Parameters.AddWithValue("@CustomerID", customerID);
                                cmd.Parameters.AddWithValue("@SaleDate", DateTime.Now);
                                cmd.Parameters.AddWithValue("@TotalAmount", cart.Sum(item => item.TotalPrice));
                                SqlParameter saleIDParam = new SqlParameter("@SaleID", SqlDbType.Int)
                                {
                                    Direction = ParameterDirection.Output
                                };
                                cmd.Parameters.Add(saleIDParam);

                                cmd.ExecuteNonQuery();
                                saleID = (int)saleIDParam.Value;
                            }

                            // Insert SaleDetails
                            foreach (var item in cart)
                            {
                                string insertSaleDetailQuery = "INSERT INTO SaleDetails (SaleID, MedicineID, Quantity, Price) " +
                                                               "VALUES (@SaleID, @MedicineID, @Quantity, @Price)";
                                using (SqlCommand cmd = new SqlCommand(insertSaleDetailQuery, conn, transaction))
                                {
                                    cmd.Parameters.AddWithValue("@SaleID", saleID);
                                    cmd.Parameters.AddWithValue("@MedicineID", item.MedicineID);
                                    cmd.Parameters.AddWithValue("@Quantity", item.Quantity);
                                    cmd.Parameters.AddWithValue("@Price", item.Price);
                                    cmd.ExecuteNonQuery();
                                }
                            }

                            transaction.Commit();
                            MessageBox.Show("Sale finalized successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            // Clear UI
                            cart.Clear();
                            UpdateCartView();
                            txtCustomerID.Clear();
                            txtCustomerName.Clear();
                            txtCustomerPhone.Clear();
                            txtCustomerEmail.Clear();
                            txtCustomerAddress.Clear();
                        }
                        catch (Exception ex)
                        {
                            transaction.Rollback();
                            MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            int customerID;
            if (!int.TryParse(txtCustomerID.Text.Trim(), out customerID))
            {
                MessageBox.Show("Customer ID must be a numeric value.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCustomerID.Clear();
                return;
            }

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    // Query to fetch all customer details
                    string query = "SELECT Name, Phone, Email, Address FROM Customers WHERE CustomerID = @CustomerID";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@CustomerID", customerID);

                        conn.Open();
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                // Populate textboxes with retrieved data
                                txtCustomerName.Text = reader["Name"]?.ToString() ?? string.Empty;
                                txtCustomerPhone.Text = reader["Phone"]?.ToString() ?? string.Empty;
                                txtCustomerEmail.Text = reader["Email"]?.ToString() ?? string.Empty;
                                txtCustomerAddress.Text = reader["Address"]?.ToString() ?? string.Empty;
                            }
                            else
                            {
                                MessageBox.Show("Customer ID not found. Please enter new customer details.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                // Clear textboxes to allow new input
                                txtCustomerName.Clear();
                                txtCustomerPhone.Clear();
                                txtCustomerEmail.Clear();
                                txtCustomerAddress.Clear();
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
