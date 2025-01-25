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

    public partial class ManageMedicinesForm : Form
    {
        public ManageMedicinesForm()
        {
            InitializeComponent();
        }

        private void Username_textBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void Username_label_Click(object sender, EventArgs e)
        {

        }

        

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;Initial Catalog=PharmacyDB;Integrated Security=True;";


        private void pictureBox1_Click_1(object sender, EventArgs e)
        {
            var mainMenuForm = new mainMenu();
            mainMenuForm.Show();

            this.Hide();
        }

        private bool SupplierExists(int supplierId)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT COUNT(*) FROM Suppliers WHERE SupplierID = @SupplierID";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@SupplierID", supplierId);

                    conn.Open();
                    int count = (int)cmd.ExecuteScalar();
                    return count > 0; // Returns true if the SupplierID exists
                }
            }
        }


        private void btnAdd_Click(object sender, EventArgs e)
        {


            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand("AddMedicine", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        // Add parameters
                        cmd.Parameters.AddWithValue("@Name", txtName.Text);
                        cmd.Parameters.AddWithValue("@BatchNo", txtBatchNo.Text);
                        cmd.Parameters.AddWithValue("@Price", decimal.Parse(txtPrice.Text));
                        cmd.Parameters.AddWithValue("@Stock", int.Parse(txtStock.Text));
                        cmd.Parameters.AddWithValue("@ExpiryDate", DateTime.Parse(txtExpiryDate.Text));
                        cmd.Parameters.AddWithValue("@SupplierID", int.Parse(txtSupplierID.Text));

                        conn.Open();
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Medicine added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadMedicines(); // Refresh DataGridView
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
           
        }

        private void LoadMedicines()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM Medicines";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    dgvMedicines.DataSource = dt;
                }
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                int medicineID = int.Parse(dgvMedicines.SelectedRows[0].Cells["MedicineID"].Value.ToString());

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand("UpdateMedicine", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        // Add parameters
                        cmd.Parameters.AddWithValue("@MedicineID", medicineID);
                        cmd.Parameters.AddWithValue("@Name", txtName.Text);
                        cmd.Parameters.AddWithValue("@BatchNo", txtBatchNo.Text);
                        cmd.Parameters.AddWithValue("@Price", decimal.Parse(txtPrice.Text));
                        cmd.Parameters.AddWithValue("@Stock", int.Parse(txtStock.Text));
                        cmd.Parameters.AddWithValue("@ExpiryDate", DateTime.Parse(txtExpiryDate.Text));
                        cmd.Parameters.AddWithValue("@SupplierID", int.Parse(txtSupplierID.Text));

                        conn.Open();
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Medicine updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadMedicines(); // Refresh DataGridView
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                int medicineID = int.Parse(dgvMedicines.SelectedRows[0].Cells["MedicineID"].Value.ToString());

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand("DeleteMedicine", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        // Add parameters
                        cmd.Parameters.AddWithValue("@MedicineID", medicineID);

                        conn.Open();
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Medicine deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadMedicines(); // Refresh DataGridView
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvMedicines_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            

        }

    private void dgvMedicines_SelectionChanged(object sender, EventArgs e)
        {
         
            
        

       }


    private void ManageMedicinesForm_Load(object sender, EventArgs e)
        {
            LoadMedicines();
        }

        private void dgvMedicines_SelectionChanged_1(object sender, EventArgs e)
        {
            try
            {
                // Check if a row is selected
                if (dgvMedicines.SelectedRows.Count > 0)
                {
                    // Get the first selected row
                    DataGridViewRow selectedRow = dgvMedicines.SelectedRows[0];

                    // Populate textboxes with data from the selected row
                    txtName.Text = selectedRow.Cells["Name"].Value?.ToString() ?? string.Empty;
                    txtBatchNo.Text = selectedRow.Cells["BatchNo"].Value?.ToString() ?? string.Empty;
                    txtPrice.Text = selectedRow.Cells["Price"].Value?.ToString() ?? string.Empty;
                    txtStock.Text = selectedRow.Cells["Stock"].Value?.ToString() ?? string.Empty;
                    txtSupplierID.Text = selectedRow.Cells["SupplierID"].Value?.ToString() ?? string.Empty;

                    // Handle ExpiryDate
                    string expiryDateString = selectedRow.Cells["ExpiryDate"].Value?.ToString();

                    if (!string.IsNullOrEmpty(expiryDateString))
                    {
                        DateTime expiryDate;

                        // Try parsing using common formats
                        string[] validFormats = { "yyyy-MM-dd", "MM/dd/yyyy", "dd/MM/yyyy" };
                        if (DateTime.TryParseExact(expiryDateString, validFormats, null, System.Globalization.DateTimeStyles.None, out expiryDate))
                        {
                            txtExpiryDate.Text = expiryDate.ToString("yyyy-MM-dd");
                        }
                        else if (DateTime.TryParse(expiryDateString, out expiryDate)) // Fallback to generic parsing
                        {
                            txtExpiryDate.Text = expiryDate.ToString("yyyy-MM-dd");
                        }
                        else
                        {
                            txtExpiryDate.Text = "Invalid Date"; // Handle invalid date
                        }
                    }
                    else
                    {
                        txtExpiryDate.Text = "No Date Provided"; // Handle null or empty date
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
