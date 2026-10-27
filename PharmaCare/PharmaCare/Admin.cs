using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PharmaCare
{
    public partial class Admin : Form
    {
        private object passward;

        public Admin()
        {
            InitializeComponent();
            this.Da = new DataAccess();
        }
        private DataAccess Da { get; set; }
       
        
        public string Usrid { get; set; }


        private void btnLogout_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to logout?", "Confirmation Message",
   MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Login log = new Login();
                log.Show();
                this.Visible = false;
            }
        }

        private void btnSeeProfile_Click(object sender, EventArgs e)
        {
            this.panelContainer.Controls.Clear();
            SeeProfile seeProfile = new SeeProfile();
            seeProfile.UserId = (string)Usrid;
            this.panelContainer.Controls.Add(seeProfile);
        }

        private void btnChangePassword_Click(object sender, EventArgs e)
        {

            this.panelContainer.Controls.Clear();
            ChangePassward password = new ChangePassward();
            password.Id = (string)Usrid;
            this.panelContainer.Controls.Add(password);
        }

        private void btnManageEmployee_Click(object sender, EventArgs e)
        {
            this.panelContainer.Controls.Clear();
            ManageEmployee emp = new  ManageEmployee();
            emp.Usid = this.Usrid;
            this.panelContainer.Controls.Add(emp);


        }

        private void btnManageAdmin_Click(object sender, EventArgs e)
        {
            this.panelContainer.Controls.Clear();
            ManageAdmin admin = new ManageAdmin();
            this.panelContainer.Controls.Add(admin);

        }

        private void btnManageProduct_Click(object sender, EventArgs e)
        {
            this.panelContainer.Controls.Clear();
            ManageProducts list = new ManageProducts();
            list.Ui = this.Usrid;
            this.panelContainer.Controls.Add(list);
        }

        private void btnSellInfo_Click(object sender, EventArgs e)
        {
            this.panelContainer.Controls.Clear();
            SellInformation list = new SellInformation();
        
            this.panelContainer.Controls.Add(list);
        }
    }
    }

