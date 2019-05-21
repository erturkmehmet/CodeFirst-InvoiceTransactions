namespace CodeFirst_Invoice.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class OriginalDB21 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Customers", "city_CityID", "dbo.Cities");
            DropIndex("dbo.Customers", new[] { "city_CityID" });
            RenameColumn(table: "dbo.Customers", name: "city_CityID", newName: "CityID");
            AlterColumn("dbo.Customers", "CityID", c => c.Int(nullable: false));
            CreateIndex("dbo.Customers", "CityID");
            AddForeignKey("dbo.Customers", "CityID", "dbo.Cities", "CityID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Customers", "CityID", "dbo.Cities");
            DropIndex("dbo.Customers", new[] { "CityID" });
            AlterColumn("dbo.Customers", "CityID", c => c.Int());
            RenameColumn(table: "dbo.Customers", name: "CityID", newName: "city_CityID");
            CreateIndex("dbo.Customers", "city_CityID");
            AddForeignKey("dbo.Customers", "city_CityID", "dbo.Cities", "CityID");
        }
    }
}
