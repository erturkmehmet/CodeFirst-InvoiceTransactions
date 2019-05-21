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
    public partial class FormCity : Form
    {
        public FormCity()
        {
            InitializeComponent();
        }
        InvoiceContext db = new InvoiceContext();
        private static int choosenCityID;

        private void FormCity_Load(object sender, EventArgs e)
        {
            FillCity();
        }
        private void FillCity()
        {
            dgvCity.DataSource = db.Cities.Select(x => new
            {
                x.CityID,        
                x.CityName
            }).ToList();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                City c = new City();
                c.CityName = txtCityName.Text;
                db.Cities.Add(c);
                db.SaveChanges();
                FillCity();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dgvCity_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                choosenCityID=Convert.ToInt32(dgvCity.CurrentRow.Cells[0].Value);
                City c = db.Cities.Where(x => x.CityID == choosenCityID).FirstOrDefault();
                txtCityName.Text = c.CityName;

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
                City c = db.Cities.Where(x => x.CityID == choosenCityID).Select(x => x).FirstOrDefault();
                c.CityName = txtCityName.Text;
                db.SaveChanges();
                FillCity();
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
                if(dgvCity.SelectedRows.Count>1)
                {
                    MessageBox.Show("For multiple delete please choose 'Delete Selected Items'");
                }
                else
                {
                    City c = db.Cities.Where(x => x.CityID == choosenCityID).Select(x => x).FirstOrDefault();
                    db.Cities.Remove(c);
                    db.SaveChanges();
                    FillCity();
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
                if (dgvCity.SelectedRows.Count < 2)
                {
                    MessageBox.Show("For the delete please choose 'Delete'");
                }
                else
                {
                    foreach (DataGridViewRow item in dgvCity.SelectedRows)
                    {

                        choosenCityID = Convert.ToInt32(item.Cells[0].Value);
                        City c = db.Cities.Find(choosenCityID);
                        db.Cities.Remove(c);
                    }
                }
                db.SaveChanges();
                FillCity();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }
    }
}
