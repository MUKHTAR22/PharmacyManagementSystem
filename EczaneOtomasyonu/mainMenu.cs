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
    public partial class mainMenu : Form
    {
        public mainMenu()
        {
            InitializeComponent();
        }

        private string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;Initial Catalog=PharmacyDB;Integrated Security=True;";

        private void LoadUnderstockedMedicines(int threshold)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    string query = "SELECT dbo.fn_CountUnderstockedMedicines(@Threshold) AS UnderstockedMedicines";
                    SqlCommand cmd = new SqlCommand(query, conn);

                    cmd.Parameters.AddWithValue("@Threshold", threshold);

                    conn.Open();
                    object result = cmd.ExecuteScalar();

                    lblUnderstockedMedicines.Text = result != null
                        ? $"{result}"
                        : "0";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading understocked medicines: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void LoadTotalCustomers()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    string query = "SELECT dbo.fn_TotalCustomers() AS TotalCustomers";
                    SqlCommand cmd = new SqlCommand(query, conn);

                    conn.Open();
                    object result = cmd.ExecuteScalar();

                    lblTotalCustomers.Text = result != null
                        ? $"{result}"
                        : "0";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading total customers: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void LoadMostSoldMedicine()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    string query = "SELECT dbo.fn_MostSoldMedicine() AS MostSold";
                    SqlCommand cmd = new SqlCommand(query, conn);

                    conn.Open();
                    object result = cmd.ExecuteScalar();

                    lblMostSoldMedicine.Text = result != null
                        ? $"{result}"
                        : "None";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading most sold medicine: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void LoadTotalSales()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    string query = "SELECT dbo.fn_TotalSales() AS TotalSales";
                    SqlCommand cmd = new SqlCommand(query, conn);

                    conn.Open();
                    object result = cmd.ExecuteScalar();

                    lblTotalSales.Text = result != null
                        ? $"{Convert.ToDecimal(result):C}" // Formats as currency
                        : "$0.00";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading total sales: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        private void Login_button_Click(object sender, EventArgs e)
        {
            
        }

        private void Exit_pictureBox_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void Doctor_pictureBox_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {
            var loginForm = new Form1();
            loginForm.Show();

            this.Hide();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void btnManageMedicines_Click(object sender, EventArgs e)
        {
            var manageMedicinesForm = new ManageMedicinesForm();
             manageMedicinesForm.Show();

            this.Hide();

        }

        private void btnSales_Click(object sender, EventArgs e)
        {
            var salesForm = new SalesForm();
            salesForm.Show();

            this.Hide();
        }

        private void btnReports_Click(object sender, EventArgs e)
        {
            var reportsForm = new ReportsForm();
            reportsForm.Show();

            this.Hide();
        }

        private void mainMenu_Load(object sender, EventArgs e)
        {
            LoadTotalSales();
            LoadMostSoldMedicine();
            LoadTotalCustomers();
            LoadUnderstockedMedicines(10); // Replace '10' with the desired threshold

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click_1(object sender, EventArgs e)
        {

        }
    }
}
