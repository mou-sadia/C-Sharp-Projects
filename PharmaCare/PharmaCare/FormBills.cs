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
    public partial class FormBills : Form
    {
        public FormBills()
        {
            InitializeComponent();
            this.Da = new DataAccess();
            this.AutoIdGenerate();
        }
        public string Us { get; set; }
        private DataAccess Da { get; set; }

        private void AutoIdGenerate()
        {
            try
            {
                var sql = "select BillsId from BillsTb order by BillsId desc;";
                var dt = this.Da.ExecuteQueryTable(sql);
                var oldId = dt.Rows[0][0].ToString();
                int num = Convert.ToInt32(oldId);
                string newId = (++num).ToString();
                this.lblBillId.Text = newId;
            }
            catch
            {
                MessageBox.Show("Auto Id Generated Failed");
            }

        }


        private void btnFinish_Click(object sender, EventArgs e)
        {
            try
            {
                //insert
                string query = @"insert into BillsTb  values(" + this.lblBillId.Text + ",'" + this.lblCustomarName.Text + "', '" + this.lblPhoneNo.Text + "', " + this.lblTotalAmount.Text + ", '" + this.dateBillCreat.Text + "', '" + this.lblEmpId.Text + "');";
                var count = this.Da.ExecuteDMLQuery(query);
            }
            catch
            {
                MessageBox.Show("Bills store  Failed");
            }
            EmployeeSellProduct employee = new EmployeeSellProduct();
            employee.Show();
            this.Visible = false;
        }
    }
}
