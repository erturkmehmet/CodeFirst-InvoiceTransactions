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
    public partial class FormViewInvoice : Form
    {
        public FormViewInvoice()
        {
            InitializeComponent();
        }
        InvoiceContext db = new InvoiceContext();
        private int chosenID;
        List<ChosenProduct> productlist = new List<ChosenProduct>();

        private void FormViewInvoice_Load(object sender, EventArgs e)
        {
            
            var comboCity = db.Cities.Select(x => new
            {
                x.CityID,
                x.CityName
            }).ToList();
            cmbCity.DisplayMember = "CityName";
            cmbCity.ValueMember = "CityID";
            cmbCity.DataSource = comboCity;
        }
        private void FillInvoice()
        {

            dgvList.DataSource = db.InvoiceDetails.Select(x => new
            {
                x.ProductID,
                x.invoiceheader.CustomerID,
                x.UnitPrice,
                x.Quantity,
                x.VATAmount,
                x.AmountWithVAT,
                GeneralAmount = x.UnitPrice*x.Quantity + (x.UnitPrice * x.Quantity) * x.VATAmount
            }).ToList();



            //dgvList.Columns[0].Visible = false;

        }

        private void cmbCity_SelectedIndexChanged(object sender, EventArgs e)
        {
            var list = db.Counties.Where(x => x.city.CityID == (int)cmbCity.SelectedValue).ToList();
            cmbCounty.DisplayMember = "CountyName";
            cmbCounty.ValueMember = "CountyID";
            cmbCounty.DataSource = list;
        }

        private void btnShowOrder_Click(object sender, EventArgs e)
        {
            FillInvoice();
        }

        private void cmbCounty_SelectedIndexChanged(object sender, EventArgs e)
        {
            var list = db.Customers.Where(x => x.CountyID == (int)cmbCounty.SelectedValue).ToList();
            cmbName.DisplayMember = "CompanyName";
            cmbName.ValueMember = "CustomerID";
            cmbName.DataSource = list;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            int selectedID =Convert.ToInt32(txtInvoiceNo.Text);
            var list = db.InvoiceDetails.Where(x => x.InvoiceID == selectedID).Select(x=>x).ToList();
            dgvList.DataSource = null;
            dgvList.DataSource = list;
        }

        private void cmbName_SelectedIndexChanged(object sender, EventArgs e)
        {
            dgvList.DataSource = db.InvoiceHeaders.Select(x => new
            {
                x.InvoiceID,
                x.CustomerID,
                x.customer.CompanyName,
                City = x.customer.county.city.CityName,
                County = x.customer.county.CountyName,
                x.InvoiceDate,
                x.PaymentDate,
                x.DeliveryNote
            }).Where(x => x.CustomerID == (int)cmbName.SelectedValue).ToList();
        }
    }
}
