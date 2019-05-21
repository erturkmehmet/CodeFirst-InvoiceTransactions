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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

  

        private void tsmCustomer_Click(object sender, EventArgs e)
        {
            FormCustomer frm = new FormCustomer();
            frm.Show();
        }

        private void tsmUnit_Click(object sender, EventArgs e)
        {
            FormUnit frm = new FormUnit();
            frm.Show();
        }

        private void tsmProduct_Click(object sender, EventArgs e)
        {
            FormProduct frm = new FormProduct();
            frm.Show();
        }

        private void tsmCity_Click(object sender, EventArgs e)
        {
            FormCity frm = new FormCity();
            frm.Show();
        }

        private void tsmCounty_Click(object sender, EventArgs e)
        {
            FormCounty frm = new FormCounty();
            frm.Show();
        }

        private void tsmInvoiceView_Click(object sender, EventArgs e)
        {
            FormViewInvoice frm = new FormViewInvoice();
            frm.Show();
        }

        private void tsmCreateInvoice_Click(object sender, EventArgs e)
        {
            FormCreateInvoice frm = new FormCreateInvoice();
            frm.Show();
        }
    }
}
