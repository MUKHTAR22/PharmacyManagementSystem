namespace EczaneOtomasyonu
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.Mogadisu_label2 = new System.Windows.Forms.Label();
            this.Mogadisu_label = new System.Windows.Forms.Label();
            this.Logo_pictureBox = new System.Windows.Forms.PictureBox();
            this.Username_label = new System.Windows.Forms.Label();
            this.Username_textBox = new System.Windows.Forms.TextBox();
            this.Password_textBox = new System.Windows.Forms.TextBox();
            this.Password_label = new System.Windows.Forms.Label();
            this.Password_checkBox = new System.Windows.Forms.CheckBox();
            this.Login_button = new System.Windows.Forms.Button();
            this.Doctor_pictureBox = new System.Windows.Forms.PictureBox();
            this.Exit_pictureBox = new System.Windows.Forms.PictureBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Logo_pictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Doctor_pictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Exit_pictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.panel1.Controls.Add(this.Mogadisu_label2);
            this.panel1.Controls.Add(this.Mogadisu_label);
            this.panel1.Controls.Add(this.Logo_pictureBox);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(209, 440);
            this.panel1.TabIndex = 0;
            // 
            // Mogadisu_label2
            // 
            this.Mogadisu_label2.AutoSize = true;
            this.Mogadisu_label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Mogadisu_label2.ForeColor = System.Drawing.Color.White;
            this.Mogadisu_label2.Location = new System.Drawing.Point(30, 238);
            this.Mogadisu_label2.Name = "Mogadisu_label2";
            this.Mogadisu_label2.Size = new System.Drawing.Size(133, 31);
            this.Mogadisu_label2.TabIndex = 2;
            this.Mogadisu_label2.Text = "Eczanesi";
            // 
            // Mogadisu_label
            // 
            this.Mogadisu_label.AutoSize = true;
            this.Mogadisu_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Mogadisu_label.ForeColor = System.Drawing.Color.White;
            this.Mogadisu_label.Location = new System.Drawing.Point(30, 207);
            this.Mogadisu_label.Name = "Mogadisu_label";
            this.Mogadisu_label.Size = new System.Drawing.Size(139, 31);
            this.Mogadisu_label.TabIndex = 1;
            this.Mogadisu_label.Text = "Mogadişu";
            // 
            // Logo_pictureBox
            // 
            this.Logo_pictureBox.Image = global::EczaneOtomasyonu.Properties.Resources.pharmacy__1_;
            this.Logo_pictureBox.Location = new System.Drawing.Point(47, 117);
            this.Logo_pictureBox.Name = "Logo_pictureBox";
            this.Logo_pictureBox.Size = new System.Drawing.Size(100, 74);
            this.Logo_pictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.Logo_pictureBox.TabIndex = 0;
            this.Logo_pictureBox.TabStop = false;
            // 
            // Username_label
            // 
            this.Username_label.AutoSize = true;
            this.Username_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Username_label.Location = new System.Drawing.Point(230, 177);
            this.Username_label.Name = "Username_label";
            this.Username_label.Size = new System.Drawing.Size(107, 20);
            this.Username_label.TabIndex = 3;
            this.Username_label.Text = "Kulanici ismi";
            this.Username_label.Click += new System.EventHandler(this.Username_label_Click);
            // 
            // Username_textBox
            // 
            this.Username_textBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Username_textBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Username_textBox.Location = new System.Drawing.Point(343, 177);
            this.Username_textBox.Name = "Username_textBox";
            this.Username_textBox.Size = new System.Drawing.Size(280, 24);
            this.Username_textBox.TabIndex = 4;
            this.Username_textBox.TextChanged += new System.EventHandler(this.Username_textBox_TextChanged);
            // 
            // Password_textBox
            // 
            this.Password_textBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Password_textBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Password_textBox.Location = new System.Drawing.Point(283, 220);
            this.Password_textBox.Name = "Password_textBox";
            this.Password_textBox.PasswordChar = '*';
            this.Password_textBox.Size = new System.Drawing.Size(340, 24);
            this.Password_textBox.TabIndex = 6;
            this.Password_textBox.TextChanged += new System.EventHandler(this.Password_textBox_TextChanged);
            // 
            // Password_label
            // 
            this.Password_label.AutoSize = true;
            this.Password_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Password_label.Location = new System.Drawing.Point(230, 217);
            this.Password_label.Name = "Password_label";
            this.Password_label.Size = new System.Drawing.Size(47, 20);
            this.Password_label.TabIndex = 5;
            this.Password_label.Text = "Şifre";
            this.Password_label.Click += new System.EventHandler(this.Password_label_Click);
            // 
            // Password_checkBox
            // 
            this.Password_checkBox.AutoSize = true;
            this.Password_checkBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Password_checkBox.Location = new System.Drawing.Point(234, 246);
            this.Password_checkBox.Name = "Password_checkBox";
            this.Password_checkBox.Size = new System.Drawing.Size(109, 20);
            this.Password_checkBox.TabIndex = 7;
            this.Password_checkBox.Text = "Şifre Göster";
            this.Password_checkBox.UseVisualStyleBackColor = true;
            this.Password_checkBox.CheckedChanged += new System.EventHandler(this.Password_checkBox_CheckedChanged);
            // 
            // Login_button
            // 
            this.Login_button.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.Login_button.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Login_button.ForeColor = System.Drawing.Color.White;
            this.Login_button.Location = new System.Drawing.Point(360, 281);
            this.Login_button.Name = "Login_button";
            this.Login_button.Size = new System.Drawing.Size(169, 48);
            this.Login_button.TabIndex = 8;
            this.Login_button.Text = "Giriş ";
            this.Login_button.UseVisualStyleBackColor = false;
            this.Login_button.Click += new System.EventHandler(this.Login_button_Click);
            // 
            // Doctor_pictureBox
            // 
            this.Doctor_pictureBox.Image = global::EczaneOtomasyonu.Properties.Resources.medical_assistance;
            this.Doctor_pictureBox.Location = new System.Drawing.Point(384, 34);
            this.Doctor_pictureBox.Name = "Doctor_pictureBox";
            this.Doctor_pictureBox.Size = new System.Drawing.Size(92, 85);
            this.Doctor_pictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.Doctor_pictureBox.TabIndex = 2;
            this.Doctor_pictureBox.TabStop = false;
            // 
            // Exit_pictureBox
            // 
            this.Exit_pictureBox.Image = global::EczaneOtomasyonu.Properties.Resources.close;
            this.Exit_pictureBox.Location = new System.Drawing.Point(650, 0);
            this.Exit_pictureBox.Name = "Exit_pictureBox";
            this.Exit_pictureBox.Size = new System.Drawing.Size(34, 34);
            this.Exit_pictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.Exit_pictureBox.TabIndex = 1;
            this.Exit_pictureBox.TabStop = false;
            this.Exit_pictureBox.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Silver;
            this.ClientSize = new System.Drawing.Size(683, 440);
            this.Controls.Add(this.Login_button);
            this.Controls.Add(this.Password_checkBox);
            this.Controls.Add(this.Password_textBox);
            this.Controls.Add(this.Password_label);
            this.Controls.Add(this.Username_textBox);
            this.Controls.Add(this.Username_label);
            this.Controls.Add(this.Doctor_pictureBox);
            this.Controls.Add(this.Exit_pictureBox);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Logo_pictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Doctor_pictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Exit_pictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox Exit_pictureBox;
        private System.Windows.Forms.PictureBox Logo_pictureBox;
        private System.Windows.Forms.PictureBox Doctor_pictureBox;
        private System.Windows.Forms.Label Mogadisu_label2;
        private System.Windows.Forms.Label Mogadisu_label;
        private System.Windows.Forms.Label Username_label;
        private System.Windows.Forms.TextBox Username_textBox;
        private System.Windows.Forms.TextBox Password_textBox;
        private System.Windows.Forms.Label Password_label;
        private System.Windows.Forms.CheckBox Password_checkBox;
        private System.Windows.Forms.Button Login_button;
    }
}

