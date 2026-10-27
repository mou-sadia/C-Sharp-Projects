using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PharmaCare
{
    public partial class SeeProfile : UserControl
    {
        public SeeProfile()
        {
            InitializeComponent();
            this.Da = new DataAccess();
        }
        private DataAccess Da { get; set; }
        
        public string UserId { get; set; }

        private void SeeProfile_Load(object sender, EventArgs e)
        {
            try
            {
                string Query = "select * from ManagerTb where ManagerId ='" + this.UserId + "';"; 
                var ds = this.Da.ExecuteQuery(Query);
                if (ds.Tables[0].Rows.Count == 1)
                { 
                    this.lblUserId.Text = ds.Tables[0].Rows[0]["ManagerId"].ToString();
                    this.lblName.Text = ds.Tables[0].Rows[0]["ManagerName"].ToString();
                    this.lblRole.Text = ds.Tables[0].Rows[0]["Role"].ToString();
                    this.lblPhoneNo.Text = ds.Tables[0].Rows[0]["PhoneNo"].ToString(); 
                    this.lblEmail.Text = ds.Tables[0].Rows[0]["Email"].ToString(); 
                    this.lblSalary.Text = ds.Tables[0].Rows[0]["Salary"].ToString(); 
                    
                } 
                else 
                { 
                    MessageBox.Show("Invalid Info"); 
                    return; 
                }
            }
            catch 
            { 
            }



        }
    }
}
