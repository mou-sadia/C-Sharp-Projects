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
    public partial class ManageEmployee : UserControl
    {
        public ManageEmployee()
        {
            InitializeComponent();
            this.Da = new DataAccess();
            this.PopulateGridView();
            this.AutoIdGenerate();
        }
        private DataAccess Da { get; set; }
        public object Usid { get; internal set; }


        public void PopulateGridView(string sql = "select * from EmployeeTb;")
        {
            var ds = this.Da.ExecuteQuery(sql);

            this.grdvEmp.AutoGenerateColumns = false;
            this.grdvEmp.DataSource = ds.Tables[0];

        }
        private void AutoIdGenerate()
        {
            try
            {
                var sql = "select EmpId from EmployeeTb order by EmpId desc;";
                var dt = this.Da.ExecuteQueryTable(sql);
                var oldId = dt.Rows[0][0].ToString();
                string[] temp = oldId.Split('-');
                int num = Convert.ToInt32(temp[1]);
                string newId = "E-" + (++num).ToString("d3");
                this.txtUserId.Text = newId;
            }
            catch { }

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
            this.dtpJoiningDate.Text = "";
            this.txtSalary.Clear();
            this.txtPassword.Clear();


            
            this.txtAutoSearch.Clear();

            this.grdvEmp.ClearSelection();
            this.AutoIdGenerate();
        }

        private void btnShowEmp_Click(object sender, EventArgs e)
        {
            this.PopulateGridView();
            this.grdvEmp.ClearSelection();
        }

        

        private void txtAutoSearch_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string sql = @"SELECT * FROM EmployeeTb 
               WHERE EmpId LIKE '" + this.txtAutoSearch.Text + @"%' 
               OR EmpName LIKE '" + this.txtAutoSearch.Text + @"%';";

                this.PopulateGridView(sql);
            }
            catch
            {
                MessageBox.Show("Error has occured");
            }
        }

        private void grdvEmp_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            this.txtUserId.Text = this.grdvEmp.CurrentRow.Cells[0].Value.ToString();
            this.txtUserName.Text = this.grdvEmp.CurrentRow.Cells[1].Value.ToString();
            this.txtRole.Text = this.grdvEmp.CurrentRow.Cells[2].Value.ToString();
            this.txtPhoneNo.Text = this.grdvEmp.CurrentRow.Cells[3].Value.ToString();
            this.txtEmail.Text = this.grdvEmp.CurrentRow.Cells[4].Value.ToString();
            this.dtpJoiningDate.Text = this.grdvEmp.CurrentRow.Cells[5].Value.ToString();
            this.txtSalary.Text = this.grdvEmp.CurrentRow.Cells[6].Value.ToString();
            this.txtPassword.Text = this.grdvEmp.CurrentRow.Cells[7].Value.ToString();

        }
        private bool IsValidToSave()
        {
            if (String.IsNullOrEmpty(this.txtUserId.Text) || String.IsNullOrEmpty(this.txtUserName.Text)
            || String.IsNullOrEmpty(this.txtRole.Text) || String.IsNullOrEmpty(this.txtPhoneNo.Text)
            || String.IsNullOrEmpty(this.txtEmail.Text) || String.IsNullOrEmpty(this.dtpJoiningDate.Text)
            || String.IsNullOrEmpty(this.txtSalary.Text) || String.IsNullOrEmpty(this.txtPassword.Text))
                return false;
            else
                return true;
        }

        private void btnAddEmp_Click(object sender, EventArgs e)
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
                    string query = @"INSERT INTO EmployeeTb
(EmpId, EmpName, Role, PhoneNo, Email, JoiningDate, Salary, Password)
VALUES ('" + this.txtUserId.Text + "', '"
          + this.txtUserName.Text + "', '"
          + this.txtRole.Text + "', '"
          + this.txtPhoneNo.Text + "', '"
          + this.txtEmail.Text + "', '"
          + this.dtpJoiningDate.Text + "', "
          + this.txtSalary.Text + ", '"
          + this.txtPassword.Text + "');";

                    var count = this.Da.ExecuteDMLQuery(query);

                    if (count == 1)
                        MessageBox.Show("Employee has been added properly");
                    else
                        MessageBox.Show("Employee added Failed");
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

        private void btnRemoveEmp_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.grdvEmp.SelectedRows.Count < 1)
                {
                    MessageBox.Show("Please select a row first to remove the data", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return;
                }

                DialogResult result = MessageBox.Show("Are you sure to remove the data?", "Alert", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
                if (result == DialogResult.No)
                    return;
                var query = "delete from EmployeeTb where EmpId = '" + this.txtUserId.Text + "';";
                var count = this.Da.ExecuteDMLQuery(query);

                if (count == 1)
                    MessageBox.Show("Employee has been removed from the list.");
                else
                    MessageBox.Show("Employee data remove failed");

                this.PopulateGridView();
                this.ClearAll();
                this.AutoIdGenerate();
            }
            catch (Exception exc)
            {
                MessageBox.Show("Error has occured:\n" + exc.Message);
            }
        }

        private void btnUpdateEmp_Click(object sender, EventArgs e)
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
                    string query = @"UPDATE EmployeeTb
        SET EmpName = '" + this.txtUserName.Text +
                    "', Role = '" + this.txtRole.Text +
                    "', PhoneNo = '" + this.txtPhoneNo.Text +
                    "', Email = '" + this.txtEmail.Text +
                    "', JoiningDate = '" + this.dtpJoiningDate.Text +
                    "', Salary = " + this.txtSalary.Text +
                    ", Password = '" + this.txtPassword.Text + "'" +
                    " WHERE EmpId = '" + this.txtUserId.Text + "';";

                    int count = this.Da.ExecuteDMLQuery(query);
                    this.PopulateGridView("select * from EmployeeTb;");

                    if (count == 1)
                    {
                        MessageBox.Show("Employee updated properly");
                    }
                    else
                    {
                        MessageBox.Show("Employee update failed! PLEASE TRY AGAIN");
                    }
                }
            }
            catch
            {
                MessageBox.Show("Error has occurred.");
            }

        }
    }
}

