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
    public partial class FormCustomer : Form
    {
        public FormCustomer()
        {
            InitializeComponent();
        }
        InvoiceContext db = new InvoiceContext();
        private static int choosenCustomerID;

        private void FormCustomer_Load(object sender, EventArgs e)
        {
            dgvCustomer.MultiSelect = true;
            dgvCustomer.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            FillCustomer();
            var combCity = db.Cities.Select(x => new
            {
                x.CityID,
                x.CityName
            }).ToList();
            cmbCustomerCity.DisplayMember = "CityName";
            cmbCustomerCity.ValueMember = "CityID";
            cmbCustomerCity.DataSource = combCity;

            //var cmbCounty = db.Counties.Select(x => new
            //{
            //    x.CountyID,
            //    x.CountyName
            //}).ToList();
            //cmbCustomerCounty.DisplayMember = "CountyName";
            //cmbCustomerCounty.ValueMember = "CountyID";
            //cmbCustomerCounty.DataSource = cmbCounty;
        }
        private void FillCustomer()
        {
            //tablo joinlemek ;önce ortak olanlar gösterilir
            //dgvCustomer.DataSource = db.Customers.Join(db.Counties, cus => cus.CountyID, coun => coun.CountyID, (cus, coun) => new
            //{
            //cus.CompanyName,
            //    cus.CustomerID,
            //    coun.CityID,
            //    coun.CountyName,
            //    cus.Address
            //}).ToList(); 
        dgvCustomer.DataSource = db.Customers.Select(x=>new
            {
                CustomerName=x.CompanyName,
                x.CustomerID,
                CityName=x.county.city.CityName,
                x.county.CountyName,
                x.Address
            }).ToList();
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {

            try
            {
                Customer c = new Customer();
                c.CompanyName = txtCustomerName.Text;           
               //c.county.CityID =Convert.ToInt32(cmbCustomerCity.SelectedValue);
                c.CountyID = Convert.ToInt32(cmbCustomerCounty.SelectedValue);
                c.Address = txtAddress.Text;
                db.Customers.Add(c);
                db.SaveChanges();
                FillCustomer();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dgvCustomer_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                choosenCustomerID = Convert.ToInt32(dgvCustomer.CurrentRow.Cells["CustomerID"].Value);
            // Customer c = db.Customers.Where(x => x.CustomerID == choosenCustomerID).FirstOrDefault();
                Customer c = db.Customers.Find(choosenCustomerID);
                txtCustomerName.Text = c.CompanyName;
                cmbCustomerCity.SelectedValue = c.county.CityID;
                cmbCustomerCounty.SelectedValue = c.CountyID;
                txtAddress.Text = c.Address;
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
                Customer c = db.Customers.Where(x => x.CustomerID == choosenCustomerID).FirstOrDefault();
                c.CompanyName = txtCustomerName.Text;
                c.county.CityID = (int)cmbCustomerCity.SelectedValue;
                c.CountyID = (int)cmbCustomerCounty.SelectedValue;
                c.Address = txtAddress.Text;
                db.SaveChanges();
                FillCustomer();
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
                if (dgvCustomer.SelectedRows.Count > 1)
                {
                    MessageBox.Show("For multiple delete please choose 'Delete Selected Items'");
                }
                else
                {
                    Customer c = db.Customers.Where(x => x.CustomerID == choosenCustomerID).Select(x => x).FirstOrDefault();
                    db.Customers.Remove(c);
                    db.SaveChanges();
                    FillCustomer();

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
                if (dgvCustomer.SelectedRows.Count < 2)
                {
                    MessageBox.Show("For the delete please choose 'Delete'");
                }
                else
                {
                    foreach (DataGridViewRow item in dgvCustomer.SelectedRows)
                    {

                        choosenCustomerID = Convert.ToInt32(item.Cells[0].Value);
                        Customer c = db.Customers.Find(choosenCustomerID);
                        db.Customers.Remove(c);
                    }
                }
                db.SaveChanges();
                FillCustomer();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void cmbCustomerCity_SelectedIndexChanged(object sender, EventArgs e)
        {
            var list = db.Counties.Where(x => x.city.CityID == (int)cmbCustomerCity.SelectedValue).ToList();
            cmbCustomerCounty.DisplayMember = "CountyName";
            cmbCustomerCounty.ValueMember = "CountyID";
            cmbCustomerCounty.DataSource = list;
        }

        private void cmbCustomerCounty_SelectedIndexChanged(object sender, EventArgs e)
        {
         

        }
    }
}
