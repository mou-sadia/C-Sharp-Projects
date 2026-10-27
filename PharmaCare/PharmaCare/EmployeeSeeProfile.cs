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
    public partial class EmployeeSeeProfile : Form
    {
        public EmployeeSeeProfile()
        {
            InitializeComponent();
            this.Da = new DataAccess();
        }
        private DataAccess Da { get; set; }
        public string Ussr { get; internal set; }

        private void btnBack_Click(object sender, EventArgs e)
        {
            Employee formEmployeePage = new Employee();
            formEmployeePage.Uss = this.Ussr;
            formEmployeePage.Show();
            this.Hide();

        }

        private void EmployeeSeeProfile_Load(object sender, EventArgs e)
        {
            try
            {
                string Query = "SELECT * FROM EmployeeTb WHERE LOWER(EmpId) = LOWER('" + this.Ussr.Trim() + "')";


                var ds = this.Da.ExecuteQuery(Query);
                if (ds.Tables[0].Rows.Count == 1)
                {
                    this.lblUserId.Text = ds.Tables[0].Rows[0][0].ToString();
                    this.lblName.Text = ds.Tables[0].Rows[0][1].ToString();
                    this.lblRole.Text = ds.Tables[0].Rows[0][2].ToString();
                    this.lblPhoneNo.Text = ds.Tables[0].Rows[0][3].ToString();
                    this.lblEmail.Text = ds.Tables[0].Rows[0][4].ToString();
                    this.lblJoindate.Text = ds.Tables[0].Rows[0][5].ToString();
                    this.lblSalary.Text = ds.Tables[0].Rows[0][6].ToString();
                }
                else
                {
                    MessageBox.Show("Invalid Info");
                    return;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading employee profile: " + ex.Message);
            }
        }
    }
}
