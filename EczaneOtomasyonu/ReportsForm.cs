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
    public partial class ReportsForm : Form
    {
        public ReportsForm()
        {
            InitializeComponent();
        }

        private void ReportsForm_Load(object sender, EventArgs e)
        {
            cmbReportType.Items.Add("Sales Report");
            cmbReportType.Items.Add("Stock Report");
            cmbReportType.Items.Add("Customer Report");
            cmbReportType.SelectedIndex = 0; // Default selection
        }

       private string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;Initial Catalog=PharmacyDB;Integrated Security=True;";



        private void btnGenerateReport_Click(object sender, EventArgs e)
        {


            string reportType = cmbReportType.SelectedItem?.ToString();
            if (string.IsNullOrEmpty(reportType))
            {
                MessageBox.Show("Please select a report type.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

           try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    string query = string.Empty;

                    // Determine query based on selected report type
                    switch (reportType)
                    {
                        case "Sales Report":
                             query = "SELECT * FROM vw_SalesSummary WHERE [Satış Tarihi] BETWEEN @StartDate AND @EndDate";
                            break;

                        case "Stock Report":
                            // Use CheckLowStock stored procedure for low stock report
                            query = "EXEC CheckLowStock @threshold";
                            break;

                        case "Customer Report":
                            query = @"SELECT CustomerID, Name AS CustomerName, Phone, Email, Address
                              FROM Customers";
                            break;

                        default:
                            MessageBox.Show("Invalid report type selected.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                    }

                    // Execute query and bind results to DataGridView
                    SqlCommand cmd = new SqlCommand(query, conn);

                    if (reportType == "Sales Report") // Add date parameters for Sales Report
                    {
                        cmd.Parameters.AddWithValue("@StartDate", dtpStartDate.Value.Date);
                        cmd.Parameters.AddWithValue("@EndDate", dtpEndDate.Value.Date);
                    }

                    
                    if (reportType == "Stock Report")
                    {
                        cmd.Parameters.AddWithValue("@threshold", 10); // Replace 10 with your desired stock threshold
                    }


                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable reportTable = new DataTable();
                    adapter.Fill(reportTable);

                    dgvReport.DataSource = reportTable; // Bind data to DataGridView
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while generating the report: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
    }
}
