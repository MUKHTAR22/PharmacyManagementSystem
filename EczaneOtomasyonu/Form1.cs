using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EczaneOtomasyonu
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Register_button_Click(object sender, EventArgs e)
        {
            
        }

        private void Password_checkBox_CheckedChanged(object sender, EventArgs e)
        {
            Password_textBox.PasswordChar = Password_checkBox.Checked ? '\0' : '*';
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Username_label_Click(object sender, EventArgs e)
        {

        }

        private void Username_textBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void Password_textBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void Password_label_Click(object sender, EventArgs e)
        {

        }

        private void Login_button_Click(object sender, EventArgs e)
        {

            // Hardcoded credentials
            string validUsername = "admin";
            string validPassword = "12345";

            // Get user input
            string enteredUsername = Username_textBox.Text.Trim();
            string enteredPassword = Password_textBox.Text.Trim();

            // Check credentials
            if (enteredUsername == validUsername && enteredPassword == validPassword)
            {
                // Login successful
                MessageBox.Show("Login successful!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Open Main Dashboard
                var mainMenuForm = new mainMenu();
                mainMenuForm.Show();

                this.Hide();
            }
            else
            {
                // Login failed
                MessageBox.Show("Invalid username or password.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


            
        }
    }
}
