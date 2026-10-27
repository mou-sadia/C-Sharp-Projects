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
    public partial class EmployeeSellProduct : Form
    {
        public EmployeeSellProduct()
        {
            InitializeComponent();
            this.Da = new DataAccess();
            this.PopulateGidView();
        }
        private DataAccess Da { get; set; }
        public string UserId { get; internal set; }

        public void PopulateGidView(string sql = "select * from MedicineTb;")
        {
            var ds = this.Da.ExecuteQuery(sql);
            this.grdvProductList.AutoGenerateColumns = false;
            this.grdvProductList.DataSource = ds.Tables[0];
        }



        private void btnBack_Click(object sender, EventArgs e)
        {
            Employee employeePage = new Employee();
            employeePage.Show();
            this.Visible = false;
        }

        private void btnLogOut_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to logout?", "Confirmation Message",
   MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Login login = new Login();
                login.Show();
                this.Visible = false;
            }
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("MedicineId");
            dt.Columns.Add("MName");
            dt.Columns.Add("Price");
            dt.Columns.Add("Quantity");

            foreach (DataGridViewRow row in grdvProductList.Rows)
            {
                bool isSelect = Convert.ToBoolean(row.Cells["Select"].Value);
                if (isSelect)
                {
                    dt.Rows.Add(row.Cells[1].Value, row.Cells[2].Value, row.Cells[5].Value, row.Cells[6].Value);
                    grdvCart.DataSource = dt;
                }
            }
        }
        public int Total { get; set; }

        private void btnGrandTotal_Click(object sender, EventArgs e)
        {
            double grandTotal = 0;
            double total = 0;

            total = Convert.ToDouble(0.01) * Convert.ToDouble(this.txtDiscount.Text);
            if (total > 0)
            {
                grandTotal = Convert.ToDouble(this.txtTotal.Text) - (Convert.ToDouble(total) * Convert.ToDouble(this.txtTotal.Text));
                this.txtGrandTotal.Text = grandTotal.ToString();
            }
            else
            {
                this.txtGrandTotal.Text = this.txtTotal.Text.ToString();
            }
        }
        private void ClearAll()
        {
            this.grdvProductList.ClearSelection();
            this.txtDiscount.Clear();
            this.txtTotal.Clear();
            this.txtGrandTotal.Clear();
        }

        private void btnClearAll_Click(object sender, EventArgs e)
        {
            this.ClearAll();
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            int total = 0;
            foreach (DataGridViewRow row in grdvCart.Rows)
            {
                int price = Convert.ToInt32(row.Cells["clmPrice"].Value) * Convert.ToInt32(row.Cells["clmQuantity"].Value); // Assuming the actual column name is "priceDataGridViewTextBoxColumn"
                total += price;
            }
            Total = total; // Store the total for later use if needed
            this.txtTotal.Text = total.ToString();

        }

        private void btnCreateBill_Click_1(object sender, EventArgs e)
        {

            if (this.txtGrandTotal != null)
            {
                try
                {
                    foreach (DataGridViewRow row in grdvCart.Rows)
                    {
                        string Query = @"update MedicineTb
                                set Quantity = " + (Convert.ToInt32(row.Cells["clmAvailable"].Value) - Convert.ToInt32(row.Cells["clmQuantity"].Value)) + @"    
                                where MedicineId = " + Convert.ToInt32(row.Cells["clmMedicineId"].Value) + ";";
                        var ds = this.Da.ExecuteDMLQuery(Query);

                    }
                    this.PopulateGidView();
                }
                catch
                {
                    MessageBox.Show("There is an error.");
                }
                FormBills bills = new FormBills();
                bills.lblEmpId.Text = this.UserId;
                bills.lblCustomarName.Text = this.txtCustomarName.Text;
                bills.lblPhoneNo.Text = this.txtCustomarPhoneNo.Text;
                bills.lblTotalAmount.Text = this.txtGrandTotal.Text;
                bills.Show();
                this.Visible = false;


            }
            else
            {
                MessageBox.Show("Please,Select product.");
                return;
            }
            this.ClearAll();
        }
    }
    }

