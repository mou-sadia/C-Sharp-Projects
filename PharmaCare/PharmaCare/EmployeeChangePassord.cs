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
    public partial class EmployeeChangePassord : Form
    {
        public EmployeeChangePassord()
        {
            InitializeComponent();
            this.Da = new DataAccess();
        }
        private DataAccess Da { get; set; }
        public string Id { get; set; }
        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Hide();
           Employee formEmployeePage = new Employee();
            formEmployeePage.Show();
        }

        private void btnChangePassword_Click(object sender, EventArgs e)
        {
            try
            {
                string sql = @"select* from EmployeeTb Where EmpId='" + this.Id + "';";
                var pa = this.Da.ExecuteQuery(sql);

                if (pa.Tables[0].Rows[0][7].ToString() == this.txtOldPass.Text)
                {
                    if (this.txtTypeNewPassword.Text != this.txtRetypeNewPassword.Text)
                    {
                        MessageBox.Show("Invalid Information");
                        return;
                    }
                    else
                    {
                        string Query = @"update EmployeeTb
                                set Password = '" + this.txtTypeNewPassword.Text + @"'    
                                where EmpId = '" + this.Id + "';";
                        var ds = this.Da.ExecuteDMLQuery(Query);
                        int count = this.Da.ExecuteDMLQuery(Query);

                        if (count == 1)

                        {

                            MessageBox.Show("Password updated");

                        }
                        else
                            MessageBox.Show("Password upgradation failed!");
                    }
                }
                else
                {
                    MessageBox.Show("Password upgradation failed! Check Old Password");
                }

            }
            catch (Exception ex)
            {

                MessageBox.Show("An error has occured, please try again.\n" + ex.Message);
            }
            this.txtTypeNewPassword.Clear();
            this.txtRetypeNewPassword.Clear();
            this.txtOldPass.Clear();
        }
    }
}
