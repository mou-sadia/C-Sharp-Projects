namespace PharmaCare
{
    partial class Employee
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
            this.lblEmployee = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnLogout = new System.Windows.Forms.Button();
            this.btmSellProduct = new System.Windows.Forms.Button();
            this.bnChangePassword = new System.Windows.Forms.Button();
            this.btnSeeProfile = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.Highlight;
            this.panel1.Controls.Add(this.pictureBox2);
            this.panel1.Controls.Add(this.lblEmployee);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.btnLogout);
            this.panel1.Controls.Add(this.btmSellProduct);
            this.panel1.Controls.Add(this.bnChangePassword);
            this.panel1.Controls.Add(this.btnSeeProfile);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(229, 732);
            this.panel1.TabIndex = 0;
            // 
            // lblEmployee
            // 
            this.lblEmployee.AutoSize = true;
            this.lblEmployee.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEmployee.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblEmployee.Location = new System.Drawing.Point(120, 186);
            this.lblEmployee.Name = "lblEmployee";
            this.lblEmployee.Size = new System.Drawing.Size(90, 20);
            this.lblEmployee.TabIndex = 7;
            this.lblEmployee.Text = "Employee";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label2.Location = new System.Drawing.Point(32, 186);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(91, 20);
            this.label2.TabIndex = 6;
            this.label2.Text = "Welcome,";
            // 
            // btnLogout
            // 
            this.btnLogout.BackColor = System.Drawing.SystemColors.Highlight;
            this.btnLogout.FlatAppearance.BorderSize = 0;
            this.btnLogout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogout.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLogout.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnLogout.Location = new System.Drawing.Point(45, 688);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(131, 38);
            this.btnLogout.TabIndex = 5;
            this.btnLogout.Text = "Log Out";
            this.btnLogout.UseVisualStyleBackColor = false;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // btmSellProduct
            // 
            this.btmSellProduct.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btmSellProduct.FlatAppearance.BorderSize = 0;
            this.btmSellProduct.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btmSellProduct.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btmSellProduct.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btmSellProduct.Location = new System.Drawing.Point(12, 398);
            this.btmSellProduct.Name = "btmSellProduct";
            this.btmSellProduct.Size = new System.Drawing.Size(193, 43);
            this.btmSellProduct.TabIndex = 4;
            this.btmSellProduct.Text = "Sell Product";
            this.btmSellProduct.UseVisualStyleBackColor = true;
            this.btmSellProduct.Click += new System.EventHandler(this.btmSellProduct_Click);
            // 
            // bnChangePassword
            // 
            this.bnChangePassword.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bnChangePassword.FlatAppearance.BorderSize = 0;
            this.bnChangePassword.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bnChangePassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bnChangePassword.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.bnChangePassword.Location = new System.Drawing.Point(12, 349);
            this.bnChangePassword.Name = "bnChangePassword";
            this.bnChangePassword.Size = new System.Drawing.Size(198, 43);
            this.bnChangePassword.TabIndex = 3;
            this.bnChangePassword.Text = "Change Password";
            this.bnChangePassword.UseVisualStyleBackColor = true;
            this.bnChangePassword.Click += new System.EventHandler(this.bnChangePassword_Click);
            // 
            // btnSeeProfile
            // 
            this.btnSeeProfile.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSeeProfile.FlatAppearance.BorderSize = 0;
            this.btnSeeProfile.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSeeProfile.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSeeProfile.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnSeeProfile.Location = new System.Drawing.Point(17, 300);
            this.btnSeeProfile.Name = "btnSeeProfile";
            this.btnSeeProfile.Size = new System.Drawing.Size(193, 43);
            this.btnSeeProfile.TabIndex = 1;
            this.btnSeeProfile.Text = "See Profile";
            this.btnSeeProfile.UseVisualStyleBackColor = true;
            this.btnSeeProfile.Click += new System.EventHandler(this.btnSeeProfile_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.Highlight;
            this.panel2.Controls.Add(this.label1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(229, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(800, 116);
            this.panel2.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Algerian", 25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label1.Location = new System.Drawing.Point(16, 45);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(411, 46);
            this.label1.TabIndex = 1;
            this.label1.Text = "Pharma Care Ltd";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.RosyBrown;
            this.label3.Font = new System.Drawing.Font("Algerian", 49.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(461, 386);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(423, 93);
            this.label3.TabIndex = 3;
            this.label3.Text = "WELCOME";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::PharmaCare.Properties.Resources.pharmacy;
            this.pictureBox1.Location = new System.Drawing.Point(225, 117);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(804, 615);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::PharmaCare.Properties.Resources.cashier;
            this.pictureBox2.Location = new System.Drawing.Point(27, 26);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(193, 144);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 2;
            this.pictureBox2.TabStop = false;
            // 
            // Employee
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1029, 732);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Employee";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Employee";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.Button btmSellProduct;
        private System.Windows.Forms.Button bnChangePassword;
        private System.Windows.Forms.Button btnSeeProfile;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblEmployee;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label3;
    }
}