using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CodeFirst_Invoice
{
    public partial class FormCounty : Form
    {
        public FormCounty()
        {
            InitializeComponent();
        }
        InvoiceContext db = new InvoiceContext();
        private static int choosenCountyID;

        private void FormCounty_Load(object sender, EventArgs e)
        {
            FillCounty();
            var comboCity = db.Cities.Select(x => new
            {
                x.CityID,
                x.CityName            
            }).ToList();
            cmbCityName.DisplayMember = "CityName";
            cmbCityName.ValueMember = "CityID";
            cmbCityName.DataSource = comboCity;
        }
        private void FillCounty()
        {
            dgvCounty.DataSource = db.Counties.Select(x => new
            {
                x.CountyID,
                x.CountyName,
                x.city.CityName
            }).ToList();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {

            try
            {
                County c = new County();
                c.CountyName = txtCountyName.Text;
                c.CityID = (int)cmbCityName.SelectedValue;
                db.Counties.Add(c);
                db.SaveChanges();
                FillCounty();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                County c = db.Counties.Where(x => x.CountyID == choosenCountyID).Select(x => x).FirstOrDefault();
                c.CountyName = txtCountyName.Text;
                c.CityID = (int)cmbCityName.SelectedValue;
                db.SaveChanges();
                FillCounty();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void dgvCounty_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                choosenCountyID = Convert.ToInt32(dgvCounty.CurrentRow.Cells[0].Value);
                County c = db.Counties.Where(x => x.CountyID == choosenCountyID).FirstOrDefault();
                txtCountyName.Text = c.CountyName;
                cmbCityName.SelectedValue = c.CityID;
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvCounty.SelectedRows.Count > 1)
                {
                    MessageBox.Show("For multiple delete please choose 'Delete Selected Items'");
                }
                else
                {
                    County c = db.Counties.Where(x => x.CountyID == choosenCountyID).Select(x => x).FirstOrDefault();
                    db.Counties.Remove(c);
                    db.SaveChanges();
                    FillCounty();

                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void btnMultipleDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvCounty.SelectedRows.Count < 2)
                {
                    MessageBox.Show("For the delete please choose 'Delete'");
                }
                else
                {
                    foreach (DataGridViewRow item in dgvCounty.SelectedRows)
                    {

                        choosenCountyID = Convert.ToInt32(item.Cells[0].Value);
                        County c = db.Counties.Find(choosenCountyID);
                        db.Counties.Remove(c);
                    }
                }
                db.SaveChanges();
                FillCounty();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
