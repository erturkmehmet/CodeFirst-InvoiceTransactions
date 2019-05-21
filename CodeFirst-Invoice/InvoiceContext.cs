namespace CodeFirst_Invoice
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity;
    using System.Linq;

    public class InvoiceContext : DbContext
    {
        // Your context has been configured to use a 'InvoiceContext' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'CodeFirst_Invoice.InvoiceContext' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'InvoiceContext' 
        // connection string in the application configuration file.
        public InvoiceContext()
            : base("name=InvoiceContext")
        {
        }

        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

        // public virtual DbSet<MyEntity> MyEntities { get; set; }
        public virtual DbSet<City> Cities { get; set; }
        public virtual DbSet<County> Counties { get; set; }
        public virtual DbSet<Unit> Units { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<InvoiceHeader> InvoiceHeaders { get; set; }
        public virtual DbSet<InvoiceDetail> InvoiceDetails { get; set; }
    }

    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}
    public class City
    {
        public City()
        {
            this.counties = new HashSet<County>();
            this.customers = new HashSet<Customer>();
        }
        public int CityID { get; set; }
        public string Description { get; set; }
        public string CityName { get; set; }
        public virtual ICollection<County> counties { get; set; }
        public virtual ICollection<Customer> customers { get; set; }

    }
    public class County
    {
        public County()
        {
            this.customers = new HashSet<Customer>();
        }
        public int CountyID { get; set; }
        public string Description { get; set; }
        public int CityID { get; set; }
        public string CountyName { get; set; }
        public virtual City city { get; set; }     
        public virtual ICollection<Customer> customers { get; set; }

    }
    public class Unit
    {
        public Unit()
        {
            this.products = new HashSet<Product>();
        }
        public int UnitID { get; set; }
        public string UnitName { get; set; }
        public virtual ICollection<Product> products { get; set; }

    }
    public class Customer
    {
        public Customer()
        {
            this.invoiceheader = new HashSet<InvoiceHeader>();
        }

        public int CustomerID { get; set; }
        public string CompanyName { get; set; }
        public int CountyID { get; set; }
        //public int CityID { get; set; }
        public string Address { get; set; }
        public string CustomerName { get; set; }
        public virtual County county { get; set; }
        public virtual City city { get; set; }

        public virtual ICollection<InvoiceHeader> invoiceheader { get; set; }

    }
    public class Product
    {
        public Product()
        {
            this.invoicedetail = new HashSet<InvoiceDetail>();
        }
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public string ProductCode { get; set; }
        public int UnitID { get; set; }
        public decimal UnitPrice { get; set; }
        public virtual ICollection<InvoiceDetail> invoicedetail { get; set; }
        public virtual Unit unit { get; set; }

    }
    public class InvoiceHeader
    {
        public InvoiceHeader()
        {
            this.invoicedetail = new HashSet<InvoiceDetail>();
            this.InvoiceDate = DateTime.Now; // fatura tarihini bug�n�n tarihi yapt�k
        }
        [Key]
        public int InvoiceID { get; set; }
        public int CustomerID { get; set; }
        public int ProductID { get; set; }
        public DateTime InvoiceDate { get; set; }
        public int DeliveryNote { get; set; }
        public DateTime PaymentDate { get; set; }
        public int TotalAmount { get; set; }
        public virtual Customer customer { get; set; }
        public virtual ICollection<InvoiceDetail> invoicedetail { get; set; }


    }
    public class InvoiceDetail
    {

        [Key] [Column(Order=0)]
        public int InvoiceID { get; set; }

         [Key] [Column(Order = 1)]
        public int ProductID { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal VATAmount { get; set; }
        public decimal AmountWithVAT { get; set; }
        public string Description { get; set; }

       public virtual Product product { get; set; } 
        public virtual InvoiceHeader invoiceheader { get; set; }

    }
}

