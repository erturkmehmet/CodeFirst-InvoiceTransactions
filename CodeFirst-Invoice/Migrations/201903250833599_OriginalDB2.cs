namespace CodeFirst_Invoice.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class OriginalDB2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "city_CityID", c => c.Int());
            CreateIndex("dbo.Customers", "city_CityID");
            AddForeignKey("dbo.Customers", "city_CityID", "dbo.Cities", "CityID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Customers", "city_CityID", "dbo.Cities");
            DropIndex("dbo.Customers", new[] { "city_CityID" });
            DropColumn("dbo.Customers", "city_CityID");
        }
    }
}
