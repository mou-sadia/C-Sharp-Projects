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
    public partial class SellInformation : UserControl
    {
        public SellInformation()
        {
            InitializeComponent();
            this.Da = new DataAccess();
            this.PopulateGridView();
        }
        private DataAccess Da { get; set; }
        public void PopulateGridView(string sql = "select * from BillsTb;")
        {
            var ds = this.Da.ExecuteQuery(sql);

            this.grdvSellInfo.AutoGenerateColumns = false;
            this.grdvSellInfo.DataSource = ds.Tables[0];
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                string sql = @"SELECT * FROM BillsTb 
                       WHERE BillsId LIKE '%" + this.txtSearch.Text + @"%' 
                       OR CustomerName LIKE '%" + this.txtSearch.Text + @"%' 
                       OR PhoneNo LIKE '%" + this.txtSearch.Text;

                this.PopulateGridView(sql);
            }
            catch
            {
                MessageBox.Show("Error has occurred");
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            this.txtSearch.Clear();
            this.grdvSellInfo.ClearSelection();
        }
    }
}
