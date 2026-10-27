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
    public partial class ManageAdmin : UserControl
    {
        public ManageAdmin()
        {
            InitializeComponent();
            this.Da = new DataAccess();
            this.PopulateGridView();
            this.AutoIdGenerate();
        }
        private DataAccess Da { get; set; }

        public void PopulateGridView(string sql = "select * from ManagerTb;")
        {
            var ds = this.Da.ExecuteQuery(sql);

            this.grdvAdmin.AutoGenerateColumns = false;
            this.grdvAdmin.DataSource = ds.Tables[0];
        }
        private void AutoIdGenerate()
        {
            try
            {
                var sql = "select ManagerId from ManagerTb order by ManagerId desc;";
                var dt = this.Da.ExecuteQueryTable(sql);
                var oldId = dt.Rows[0][0].ToString();
                string[] temp = oldId.Split('-');
                int num = Convert.ToInt32(temp[1]);
                string newId = "M-" + (++num).ToString("d3");
                this.txtUserId.Text = newId;
            }
            catch
            {
                MessageBox.Show("Error has occured");
            }

        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            this.ClearAll();
            this.AutoIdGenerate();
        }
        private void ClearAll()
        {
            this.txtUserId.Clear();
            this.txtUserName.Text = "";
            this.txtRole.Clear();
            this.txtPhoneNo.Clear();
            this.txtEmail.Clear();
            this.txtSalary.Clear();
            this.txtPassword.Clear();


            this.txtSearch.Clear();


            this.grdvAdmin.ClearSelection();
            this.AutoIdGenerate();
        }


        private void btnShowAdmin_Click(object sender, EventArgs e)
        {
            this.PopulateGridView();
            this.grdvAdmin.ClearSelection();
        }
        private bool IsValidToSave()
        {
            if (String.IsNullOrEmpty(this.txtUserId.Text) || String.IsNullOrEmpty(this.txtUserName.Text)
            || String.IsNullOrEmpty(this.txtRole.Text) || String.IsNullOrEmpty(this.txtPhoneNo.Text)
            || String.IsNullOrEmpty(this.txtEmail.Text) || String.IsNullOrEmpty(this.txtSalary.Text) || String.IsNullOrEmpty(this.txtPassword.Text))
                return false;
            else
                return true;
        }

        private void btnAddAdmin_Click(object sender, EventArgs e)
        {
            try
            {
                if (!this.IsValidToSave())
                {
                    MessageBox.Show("Please fill all the information");
                    return;
                }



                else
                {

                    string query = @"INSERT INTO ManagerTb
                (ManagerId, ManagerName, Role, PhoneNo, Email, Salary, Password)
                VALUES ('" + this.txtUserId.Text + "', '"
                          + this.txtUserName.Text + "', '"
                          + this.txtRole.Text + "', '"
                          + this.txtPhoneNo.Text + "', '"
                          + this.txtEmail.Text + "', "
                          + this.txtSalary.Text + ", '"
                          + this.txtPassword.Text + "');";

                    var count = this.Da.ExecuteDMLQuery(query);

                    if (count == 1)
                        MessageBox.Show("Manager has been added properly");
                    else
                        MessageBox.Show("Manager added Failed");
                }

                this.PopulateGridView();
                this.ClearAll();
                this.AutoIdGenerate();
            }
            catch (Exception exc)
            {
                MessageBox.Show("Error has occured:\n" + exc.Message);
            }
        }

        private void btnRemoveAdmin_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.grdvAdmin.SelectedRows.Count < 1)
                {
                    MessageBox.Show("Please select a row first to remove the data", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return;
                }

                DialogResult result = MessageBox.Show("Are you sure to remove the data?", "Alert", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
                if (result == DialogResult.No)
                    return;
                var query = "delete from ManagerTb where ManagerId = '" + this.txtUserId.Text + "';";
                var count = this.Da.ExecuteDMLQuery(query);

                if (count == 1)
                    MessageBox.Show("Manager data has been removed from the list.");
                else
                    MessageBox.Show("Manager data remove failed");

                this.PopulateGridView();
                this.ClearAll();
                this.AutoIdGenerate();
            }
            catch (Exception exc)
            {
                MessageBox.Show("Error has occured:\n" + exc.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (!this.IsValidToSave())
                {
                    MessageBox.Show("Please fill all the information");
                    return;
                }
                else
                {
                    string query = @"UPDATE ManagerTb
                 SET ManagerName = '" + this.txtUserName.Text +
                 "', Role = '" + this.txtRole.Text +
                 "', PhoneNo = '" + this.txtPhoneNo.Text +
                 "', Email = '" + this.txtEmail.Text +
                 "', Salary = " + this.txtSalary.Text +
                 ", Password = '" + this.txtPassword.Text + "'" +
                 " WHERE ManagerId = '" + this.txtUserId.Text + "';";


                    int count = this.Da.ExecuteDMLQuery(query);
                    this.PopulateGridView();

                    if (count == 1)
                    {
                        MessageBox.Show("Manager updated properly");
                    }
                    else
                    {
                        MessageBox.Show("Manager update failed! PLEASE TRY AGAIN");
                    }
                }
            }
            catch
            {
                MessageBox.Show("Error has occurred.");
            }

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                string sql = @"select* from ManagerTb Where ManagerId='" + this.txtSearch.Text + "'or ManagerName='" + this.txtSearch.Text + "' or PhoneNo='" + this.txtSearch.Text + "';";
                this.PopulateGridView(sql);
            }
            catch
            {
                MessageBox.Show("Error has occured");
            }

        }

        private void grdvAdmin_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            this.txtUserId.Text = this.grdvAdmin.CurrentRow.Cells[0].Value.ToString();
            this.txtUserName.Text = this.grdvAdmin.CurrentRow.Cells[1].Value.ToString();
            this.txtRole.Text = this.grdvAdmin.CurrentRow.Cells[2].Value.ToString();
            this.txtPhoneNo.Text = this.grdvAdmin.CurrentRow.Cells[3].Value.ToString();
            this.txtEmail.Text = this.grdvAdmin.CurrentRow.Cells[4].Value.ToString();
            this.txtSalary.Text = this.grdvAdmin.CurrentRow.Cells[5].Value.ToString();
            this.txtPassword.Text = this.grdvAdmin.CurrentRow.Cells[6].Value.ToString();
        }
    }
    }
    

