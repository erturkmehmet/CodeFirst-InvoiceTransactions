namespace CodeFirst_Invoice
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.tsmSupport = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmCustomer = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmUnit = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmProduct = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmCity = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmCounty = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmInvoice = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmInvoiceView = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmCreateInvoice = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmSupport,
            this.tsmInvoice});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // tsmSupport
            // 
            this.tsmSupport.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmCustomer,
            this.tsmUnit,
            this.tsmProduct,
            this.tsmCity,
            this.tsmCounty});
            this.tsmSupport.Name = "tsmSupport";
            this.tsmSupport.Size = new System.Drawing.Size(97, 20);
            this.tsmSupport.Text = "Support Tables";
            // 
            // tsmCustomer
            // 
            this.tsmCustomer.Name = "tsmCustomer";
            this.tsmCustomer.Size = new System.Drawing.Size(183, 22);
            this.tsmCustomer.Text = "Customer Definitons";
            this.tsmCustomer.Click += new System.EventHandler(this.tsmCustomer_Click);
            // 
            // tsmUnit
            // 
            this.tsmUnit.Name = "tsmUnit";
            this.tsmUnit.Size = new System.Drawing.Size(183, 22);
            this.tsmUnit.Text = "Unit Definitons";
            this.tsmUnit.Click += new System.EventHandler(this.tsmUnit_Click);
            // 
            // tsmProduct
            // 
            this.tsmProduct.Name = "tsmProduct";
            this.tsmProduct.Size = new System.Drawing.Size(183, 22);
            this.tsmProduct.Text = "Product Definitons";
            this.tsmProduct.Click += new System.EventHandler(this.tsmProduct_Click);
            // 
            // tsmCity
            // 
            this.tsmCity.Name = "tsmCity";
            this.tsmCity.Size = new System.Drawing.Size(183, 22);
            this.tsmCity.Text = "City Definitons";
            this.tsmCity.Click += new System.EventHandler(this.tsmCity_Click);
            // 
            // tsmCounty
            // 
            this.tsmCounty.Name = "tsmCounty";
            this.tsmCounty.Size = new System.Drawing.Size(183, 22);
            this.tsmCounty.Text = "County Definitons";
            this.tsmCounty.Click += new System.EventHandler(this.tsmCounty_Click);
            // 
            // tsmInvoice
            // 
            this.tsmInvoice.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmInvoiceView,
            this.tsmCreateInvoice});
            this.tsmInvoice.Name = "tsmInvoice";
            this.tsmInvoice.Size = new System.Drawing.Size(126, 20);
            this.tsmInvoice.Text = "Invoice Transactions";
            // 
            // tsmInvoiceView
            // 
            this.tsmInvoiceView.Name = "tsmInvoiceView";
            this.tsmInvoiceView.Size = new System.Drawing.Size(202, 22);
            this.tsmInvoiceView.Text = "Invoice View/Query/Edit";
            this.tsmInvoiceView.Click += new System.EventHandler(this.tsmInvoiceView_Click);
            // 
            // tsmCreateInvoice
            // 
            this.tsmCreateInvoice.Name = "tsmCreateInvoice";
            this.tsmCreateInvoice.Size = new System.Drawing.Size(202, 22);
            this.tsmCreateInvoice.Text = "Create New Invoice";
            this.tsmCreateInvoice.Click += new System.EventHandler(this.tsmCreateInvoice_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Form1";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem tsmSupport;
        private System.Windows.Forms.ToolStripMenuItem tsmCustomer;
        private System.Windows.Forms.ToolStripMenuItem tsmUnit;
        private System.Windows.Forms.ToolStripMenuItem tsmProduct;
        private System.Windows.Forms.ToolStripMenuItem tsmCity;
        private System.Windows.Forms.ToolStripMenuItem tsmCounty;
        private System.Windows.Forms.ToolStripMenuItem tsmInvoice;
        private System.Windows.Forms.ToolStripMenuItem tsmInvoiceView;
        private System.Windows.Forms.ToolStripMenuItem tsmCreateInvoice;
    }
}

