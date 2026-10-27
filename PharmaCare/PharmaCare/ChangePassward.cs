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
    public partial class ChangePassward : UserControl
    {
        public ChangePassward()
        {
            InitializeComponent();
            this.Da = new DataAccess();
        }
        private DataAccess Da { get; set; }

        public string Id { get; set; }
       
        private void btnChangePassword_Click(object sender, EventArgs e)
        {
            try
            {
                string sql = @"select* from ManagerTb Where ManagerId='" + this.Id + "';";
                var pa = this.Da.ExecuteQuery(sql);

                if (pa.Tables[0].Rows[0][6].ToString() == this.txtOldPass.Text)
                {
                    if (this.txtTypeNewPassword.Text != this.txtRetypeNewPassword.Text)
                    {
                        MessageBox.Show("Invalid Info");
                        this.txtOldPass.Clear();
                        this.txtTypeNewPassword.Clear();
                        this.txtRetypeNewPassword.Clear();
                        return;
                    }
                    else
                    {
                        string Query = @"update ManagerTb
                                set Password = '" + this.txtTypeNewPassword.Text + @"'    
                                where ManagerId = '" + this.Id + "';";
                        var ds = this.Da.ExecuteDMLQuery(Query);
                        int count = this.Da.ExecuteDMLQuery(Query);

                        if (count == 1)

                        {

                            MessageBox.Show("Password updated properly");

                        }
                        else
                        {
                            MessageBox.Show("Password upgradation failed! PLEASE TRY AGAIN");
                        }
                        this.txtOldPass.Clear();
                        this.txtTypeNewPassword.Clear();
                        this.txtRetypeNewPassword.Clear();

                    }
                }
                else
                {

                    MessageBox.Show("Password update failed! Check Old Password");
                    this.txtOldPass.Clear();
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

