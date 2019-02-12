namespace AutoLotDALEF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CreditRisk",
                c => new
                    {
                        CustID = c.Int(nullable: false),
                        FirstName = c.String(maxLength: 50, fixedLength: true),
                        LastName = c.String(maxLength: 50, fixedLength: true),
                    })
                .PrimaryKey(t => t.CustID);
            
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        CustID = c.Int(nullable: false),
                        FirstName = c.String(maxLength: 50, unicode: false),
                        LastName = c.String(maxLength: 50, unicode: false),
                    })
                .PrimaryKey(t => t.CustID);
            
            CreateTable(
                "dbo.Inventory",
                c => new
                    {
                        CarID = c.Int(nullable: false),
                        Make = c.String(maxLength: 50, unicode: false),
                        Color = c.String(maxLength: 50, unicode: false),
                        PetName = c.String(maxLength: 50, unicode: false),
                    })
                .PrimaryKey(t => t.CarID);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        OrderID = c.Int(nullable: false),
                        CustID = c.Int(nullable: false),
                        CarID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.OrderID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Orders");
            DropTable("dbo.Inventory");
            DropTable("dbo.Customers");
            DropTable("dbo.CreditRisk");
        }
    }
}
