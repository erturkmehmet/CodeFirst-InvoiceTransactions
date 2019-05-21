using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CodeFirst_Invoice
{
    public partial class FormCreateInvoice : Form
    {
        public FormCreateInvoice()
        {
            InitializeComponent();
        }

        InvoiceContext db = new InvoiceContext();
        private int chosenID;
        List<ChosenProduct> productlist = new List<ChosenProduct>();

        private void FormCreateInvoice_Load(object sender, EventArgs e)
        {
            FillInvoice();
            var cmbCity = db.Cities.Select(x => new
            {
                x.CityID,
                x.CityName
            }).ToList();
            cmbCustCity.DisplayMember = "CityName";
            cmbCustCity.ValueMember = "CityID";
            cmbCustCity.DataSource = cmbCity;

            //var cmbCounty = db.Counties.Select(x => new
            //{
            //    x.CountyID,
            //    x.CountyName
            //}).ToList();
            //cmbCustCounty.DisplayMember = "CountyName";
            //cmbCustCounty.ValueMember = "CountyID";
            //cmbCustCounty.DataSource = cmbCounty;


            var cmbCustomer = db.Customers.Select(x => new
            {
                x.CustomerID,
                x.CompanyName
            }).ToList();
            cmbCust.DisplayMember = "CompanyName";
            cmbCust.ValueMember = "CustomerID";
            cmbCust.DataSource = cmbCustomer;


            var cmbProduct = db.Products.Select(x => new
            {
                x.ProductID,
                x.ProductName
            }).ToList();
            cmbProdName.DisplayMember = "ProductName";
            cmbProdName.ValueMember = "ProductID";
            cmbProdName.DataSource = cmbProduct;
        }
        private void FillInvoice()
        {
            dgvList.DataSource = productlist.Select(x => new
            {
                x.ProductID,
                x.ProductName,
                x.UnitPrice,
                x.Quantity,
                x.VAT,
                x.TotalAmount,
                GeneralAmount=x.TotalAmount+x.TotalAmount*x.VAT
            }).ToList();
            dgvList.Columns[0].Visible = false;
            Clear();
            TotalInvoice();
            
        }
        private void Clear()
        {
            nudQuantity.Value = 0;
        }
        private void TotalInvoice()
        {
            decimal total = 0;
            for(int i=0;i<dgvList.Rows.Count;i++)
            {
                total +=Convert.ToDecimal(dgvList[6,i].Value);
            }
            lblTotalInvoice.Text = Convert.ToString(String.Format("{0:0.00}", total + "TL"));
            total = Math.Round(total, 2);
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            //eğer listede var ise ekleme(cmbprodname) yok ise aşağıdakiler
            productlist.Add(new ChosenProduct
            {
                ProductID = (int)cmbProdName.SelectedValue,
                ProductName = cmbProdName.Text,
                UnitPrice = Convert.ToDecimal(txtProdPrice.Text),
                VAT=Convert.ToDecimal(txtProdVAT.Text),
                Quantity=(decimal)nudQuantity.Value,
                TotalAmount=Convert.ToDecimal(txtProdPrice.Text)*(decimal)nudQuantity.Value
            });
            FillInvoice();
        }

        private void btnSaveInvoice_Click(object sender, EventArgs e)
        {
            DbContextTransaction tran = db.Database.BeginTransaction();
            try
            {
                SaveInvoice();
                SaveInvoiceDetails();
                tran.Commit();
            }
            
            catch (Exception ex)
            {
                tran.Rollback();
                MessageBox.Show(ex.Message);
            }
        }
        private void SaveInvoice()
        {
          
                InvoiceHeader iHead = new InvoiceHeader();
                iHead.DeliveryNote = Convert.ToInt32(txtDeliveryNote.Text);
                iHead.PaymentDate = dtpPaymentDate.Value;
                iHead.CustomerID=(int)cmbCust.SelectedValue;
                
                db.InvoiceHeaders.Add(iHead);
                db.SaveChanges();
                lblInvoiceNo.Text = iHead.InvoiceID.ToString();            
        }
        private void SaveInvoiceDetails()
        {
            foreach (ChosenProduct item in productlist)
            {
                InvoiceDetail id = new InvoiceDetail();
                id.InvoiceID = Convert.ToInt32(lblInvoiceNo.Text);
                id.ProductID = item.ProductID;
                id.Quantity = (int)item.Quantity;
                id.UnitPrice = item.UnitPrice;
                id.VATAmount = item.VAT;
                id.AmountWithVAT = id.Quantity * item.UnitPrice * id.VATAmount;

                db.InvoiceDetails.Add(id);
                db.SaveChanges();
            }
        }
        private void btnClearList_Click(object sender, EventArgs e)
        {
            dgvList.Columns.Clear();
            productlist.Clear();
        }

        private void cmbCustCity_SelectedIndexChanged(object sender, EventArgs e)
        {
            var list = db.Counties.Where(x => x.city.CityID == (int)cmbCustCity.SelectedValue).ToList();
            cmbCustCounty.DisplayMember = "CountyName";
            cmbCustCounty.ValueMember = "CountyID";
            cmbCustCounty.DataSource = list;
        }

        private void cmbProdName_SelectedIndexChanged(object sender, EventArgs e)
        {
            decimal price = db.Products.Find((int)cmbProdName.SelectedValue).UnitPrice;
            txtProdPrice.Text = price.ToString();
            string unit = db.Products.Find((int)cmbProdName.SelectedValue).unit.UnitName;
            txtProdUnit.Text = unit;
            txtProdVAT.Text = "0,18";
        }

        private void dgvList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            chosenID =(int) dgvList.CurrentRow.Cells[0].Value;
            var p = productlist.Where(x => x.ProductID == chosenID).FirstOrDefault();
            cmbProdName.SelectedValue = chosenID;
            nudQuantity.Value = p.Quantity;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                var p = productlist.Where(x => x.ProductID == chosenID).FirstOrDefault();
                if(chosenID==(int)cmbProdName.SelectedValue)
                {
                    p.Quantity =(decimal) nudQuantity.Value;
                    p.TotalAmount = Convert.ToDecimal(txtProdPrice.Text) * (decimal)nudQuantity.Value;
                }
                else
                {
                    p.ProductID =(int) cmbProdName.SelectedValue;
                    p.ProductName = cmbProdName.Text;
                    p.UnitPrice = Convert.ToDecimal(txtProdPrice.Text);
                    p.Quantity = nudQuantity.Value;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                var p = productlist.Where(x => x.ProductID == chosenID).FirstOrDefault();
                productlist.Remove(p);
                FillInvoice();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }
    }
}
