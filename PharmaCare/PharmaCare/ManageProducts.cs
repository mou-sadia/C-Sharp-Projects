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
    public partial class ManageProducts : UserControl
    {
        public ManageProducts()
        {
            InitializeComponent();
            this.Da = new DataAccess();
            this.PopulateGridView();
            this.AutoIdGenerate();
        }
        private DataAccess Da { get; set; }
        public void PopulateGridView(string sql = "select * from MedicineTb;")
        {
            var ds = this.Da.ExecuteQuery(sql);

            this.grdvMedicine.AutoGenerateColumns = false;
            this.grdvMedicine.DataSource = ds.Tables[0];


        }
        public object Ui { get; internal set; }

        private void grdvMedicine_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            this.txtMedicineId.Text = this.grdvMedicine.CurrentRow.Cells[0].Value.ToString();
            this.txtMName.Text = this.grdvMedicine.CurrentRow.Cells[1].Value.ToString();
            this.txtGeniric.Text = this.grdvMedicine.CurrentRow.Cells[2].Value.ToString();
            this.txtType.Text = this.grdvMedicine.CurrentRow.Cells[3].Value.ToString();
            this.txtPrice.Text = this.grdvMedicine.CurrentRow.Cells[4].Value.ToString();
            this.txtQuantity.Text = this.grdvMedicine.CurrentRow.Cells[5].Value.ToString();
        }
        private void AutoIdGenerate()
        {
            try
            {
                var sql = "select MedicineId from MedicineTb order by MedicineId desc;";
                var dt = this.Da.ExecuteQueryTable(sql);

                if (dt.Rows.Count == 0) 
                {
                    this.txtMedicineId.Text = "1";
                    return;
                }

                var oldId = dt.Rows[0][0].ToString();
                int num = Convert.ToInt32(oldId); 
                string newId = (++num).ToString();
                this.txtMedicineId.Text = newId;
            }
            catch (Exception)
            {
                MessageBox.Show("Auto Id Generated Failed");
            }
        }

        private bool IsValidToSave()
        {
            if (String.IsNullOrEmpty(this.txtMedicineId.Text) || String.IsNullOrEmpty(this.txtMName.Text)
            || String.IsNullOrEmpty(this.txtGeniric.Text) || String.IsNullOrEmpty(this.txtType.Text)
            || String.IsNullOrEmpty(this.txtPrice.Text) || String.IsNullOrEmpty(this.txtQuantity.Text))
                return false;
            else
                return true;
        }
        private void ClearAll()
        {
            this.txtMedicineId.Clear();
            this.txtMName.Text = "";
            this.txtGeniric.Clear();
            this.txtType.Clear();
            this.txtPrice.Clear();
            this.txtQuantity.Clear();


            
            this.txtAutoSearch.Clear();

            this.grdvMedicine.ClearSelection();
            this.AutoIdGenerate();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            this.ClearAll();
            this.AutoIdGenerate();
        }

        private void btnShowMedicine_Click(object sender, EventArgs e)
        {
            this.PopulateGridView();

        }

        private void txtAutoSearch_TextChanged(object sender, EventArgs e)
        {
            string sql = @"select* from MedicineTb Where MedicineId like'" + this.txtAutoSearch.Text + "%'or MName like'" + this.txtAutoSearch.Text + "%'or Generic like'" + this.txtAutoSearch.Text + "%';";
            this.PopulateGridView(sql);
        }

       
           
        

        private void btnAddMedicine_Click(object sender, EventArgs e)
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

                    string query = @"insert into MedicineTb
(MedicineId, MName, Generic, Type, Price, Quantity)
values(" + this.txtMedicineId.Text + ", '"
       + this.txtMName.Text + "', '"
       + this.txtGeniric.Text + "', '"
       + this.txtType.Text + "', "
       + this.txtPrice.Text + ", "
       + this.txtQuantity.Text + ");";

                    var count = this.Da.ExecuteDMLQuery(query);

                    if (count == 1)
                        MessageBox.Show("New Medicine has been added properly");
                    else
                        MessageBox.Show("New Medicine added Failed");
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

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.grdvMedicine.SelectedRows.Count < 1)
                {
                    MessageBox.Show("Please select a row first to remove the data", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return;
                }

                DialogResult result = MessageBox.Show("Are you sure to remove the data?", "Alert", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
                if (result == DialogResult.No)
                    return;
                var query = "delete from MedicineTb where MedicineId = '" + this.txtMedicineId.Text + "';";
                var count = this.Da.ExecuteDMLQuery(query);

                if (count == 1)
                    MessageBox.Show("Medicine has been removed from the list.");
                else
                    MessageBox.Show("Medicine data remove failed");

                this.PopulateGridView();
                this.ClearAll();
                this.AutoIdGenerate();
            }
            catch (Exception exc)
            {
                MessageBox.Show("Error has occured:\n" + exc.Message);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
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
                    string Query = @"update MedicineTb
                                set MName = '" + this.txtMName.Text + "',Generic='" + this.txtGeniric.Text + "',Type='" + this.txtType.Text + "',Price=" + this.txtPrice.Text + ",Quantity=" + this.txtQuantity.Text + " where MedicineId = " + this.txtMedicineId.Text + ";";
                    var ds = this.Da.ExecuteDMLQuery(Query);
                    int count = this.Da.ExecuteDMLQuery(Query);
                    this.PopulateGridView();

                    if (count == 1)

                    {

                        MessageBox.Show("Medicine updated properly");

                    }
                    else
                        MessageBox.Show("Medicine upgradation failed! PLEASE TRY AGAIN");
                }

            }
            catch
            {
                MessageBox.Show("Error has occured.");
            }
        }

    }
}
    



