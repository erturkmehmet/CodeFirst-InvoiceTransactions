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
    public partial class FormProduct : Form
    {
        public FormProduct()
        {
            InitializeComponent();
        }
        InvoiceContext db = new InvoiceContext();
        private static int choosenProductID;

        private void FormProduct_Load(object sender, EventArgs e)
        {
            FillProduct();
            var cmbUnit=db.Units.Select(x => new
            {
                x.UnitID,
                x.UnitName
            }).ToList();
            cmbUnitName.DisplayMember = "UnitName";
            cmbUnitName.ValueMember = "UnitID";
            cmbUnitName.DataSource = cmbUnit;
            
        }
        private void FillProduct()
        {
            dgvProduct.DataSource = db.Products.Select(x => new
            {
                x.ProductID,
                x.ProductName,
                x.ProductCode,
                x.unit.UnitName,
                x.UnitPrice
            }).ToList();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {

            //try
            //{
                Product p = new Product();
                p.ProductName = txtProductName.Text;
                p.ProductCode = txtProductCode.Text;
                p.UnitID = Convert.ToInt32(cmbUnitName.SelectedValue);
                p.UnitPrice= Convert.ToDecimal(txtUnitPrice.Text);
                db.Products.Add(p);
                db.SaveChanges();
                FillProduct();
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message);
            //}
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                Product p = db.Products.Where(x => x.ProductID == choosenProductID).FirstOrDefault();
                p.ProductName = txtProductName.Text;
                p.ProductCode = txtProductCode.Text;
                p.unit.UnitName = cmbUnitName.SelectedValue.ToString();
                p.UnitPrice =Convert.ToDecimal( txtUnitPrice.Text);
                db.SaveChanges();
                FillProduct();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void dgvProduct_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                choosenProductID = Convert.ToInt32(dgvProduct.CurrentRow.Cells[0].Value);
                Product p = db.Products.Where(x => x.ProductID == choosenProductID).FirstOrDefault();
                txtProductName.Text =p.ProductName;
                txtProductCode.Text = p.ProductCode;
                cmbUnitName.SelectedValue = p.unit.UnitName;
                txtUnitPrice.Text = p.UnitPrice.ToString();
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
                if (dgvProduct.SelectedRows.Count > 1)
                {
                    MessageBox.Show("For multiple delete please choose 'Delete Selected Items'");
                }
                else
                {
                    Product p = db.Products.Where(x => x.ProductID == choosenProductID).Select(x => x).FirstOrDefault();
                    db.Products.Remove(p);
                    db.SaveChanges();
                    FillProduct();

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
                if (dgvProduct.SelectedRows.Count < 2)
                {
                    MessageBox.Show("For the delete please choose 'Delete'");
                }
                else
                {
                    foreach (DataGridViewRow item in dgvProduct.SelectedRows)
                    {

                        choosenProductID = Convert.ToInt32(item.Cells[0].Value);
                        Product p = db.Products.Find(choosenProductID);
                        db.Products.Remove(p);
                    }
                }
                db.SaveChanges();
                FillProduct();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
