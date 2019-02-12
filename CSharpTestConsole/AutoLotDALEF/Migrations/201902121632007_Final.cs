namespace AutoLotDALEF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Final : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.CreditRisk");
            DropPrimaryKey("dbo.Customers");
            DropPrimaryKey("dbo.Inventory");
            DropPrimaryKey("dbo.Orders");

            DropColumn("dbo.CreditRisk", "CustID");
            DropColumn("dbo.Customers", "CustID");
            DropColumn("dbo.Inventory", "CarID");
            DropColumn("dbo.Orders", "OrderID");
            DropColumn("dbo.Orders", "CustID");

            AddColumn("dbo.CreditRisk", "Id", c => c.Int(nullable: false, identity: true));
            AddColumn("dbo.CreditRisk", "Timestamp", c => c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"));
            AddColumn("dbo.Customers", "Id", c => c.Int(nullable: false, identity: true));
            AddColumn("dbo.Customers", "Timestamp", c => c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"));
            AddColumn("dbo.Inventory", "Id", c => c.Int(nullable: false, identity: true));
            AddColumn("dbo.Inventory", "Timestamp", c => c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"));
            AddColumn("dbo.Orders", "Id", c => c.Int(nullable: false, identity: true));
            AddColumn("dbo.Orders", "CustomerID", c => c.Int(nullable: false));
            AddColumn("dbo.Orders", "Timestamp", c => c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "rowversion"));
            AddPrimaryKey("dbo.CreditRisk", "Id");
            AddPrimaryKey("dbo.Customers", "Id");
            AddPrimaryKey("dbo.Inventory", "Id");
            AddPrimaryKey("dbo.Orders", "Id");
            CreateIndex("dbo.CreditRisk", new[] { "LastName", "FirstName" }, unique: true, name: "IDX_CreditRisk_Name");
            CreateIndex("dbo.Orders", "CustomerID");
            CreateIndex("dbo.Orders", "CarID");
            AddForeignKey("dbo.Orders", "CarID", "dbo.Inventory", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Orders", "CustomerID", "dbo.Customers", "Id", cascadeDelete: true);
            //DropColumn("dbo.CreditRisk", "CustID");
            //DropColumn("dbo.Customers", "CustID");
            //DropColumn("dbo.Inventory", "CarID");
            //DropColumn("dbo.Orders", "OrderID");
            //DropColumn("dbo.Orders", "CustID");
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.Orders");
            DropPrimaryKey("dbo.Inventory");
            DropPrimaryKey("dbo.Customers");
            DropPrimaryKey("dbo.CreditRisk");
            DropColumn("dbo.Orders", "Timestamp");
            DropColumn("dbo.Orders", "CustomerID");
            DropColumn("dbo.Orders", "Id");
            DropColumn("dbo.Inventory", "Timestamp");
            DropColumn("dbo.Inventory", "Id");
            DropColumn("dbo.Customers", "Timestamp");
            DropColumn("dbo.Customers", "Id");
            DropColumn("dbo.CreditRisk", "Timestamp");
            DropColumn("dbo.CreditRisk", "Id");

            AddColumn("dbo.Orders", "CustID", c => c.Int(nullable: false));
            AddColumn("dbo.Orders", "OrderID", c => c.Int(nullable: false));
            AddColumn("dbo.Inventory", "CarID", c => c.Int(nullable: false));
            AddColumn("dbo.Customers", "CustID", c => c.Int(nullable: false));
            AddColumn("dbo.CreditRisk", "CustID", c => c.Int(nullable: false));
            DropForeignKey("dbo.Orders", "CustomerID", "dbo.Customers");
            DropForeignKey("dbo.Orders", "CarID", "dbo.Inventory");
            DropIndex("dbo.Orders", new[] { "CarID" });
            DropIndex("dbo.Orders", new[] { "CustomerID" });
            DropIndex("dbo.CreditRisk", "IDX_CreditRisk_Name");
            //DropPrimaryKey("dbo.Orders");
            //DropPrimaryKey("dbo.Inventory");
            //DropPrimaryKey("dbo.Customers");
            //DropPrimaryKey("dbo.CreditRisk");
            //DropColumn("dbo.Orders", "Timestamp");
            //DropColumn("dbo.Orders", "CustomerID");
            //DropColumn("dbo.Orders", "Id");
            //DropColumn("dbo.Inventory", "Timestamp");
            //DropColumn("dbo.Inventory", "Id");
            //DropColumn("dbo.Customers", "Timestamp");
            //DropColumn("dbo.Customers", "Id");
            //DropColumn("dbo.CreditRisk", "Timestamp");
            //DropColumn("dbo.CreditRisk", "Id");
            AddPrimaryKey("dbo.Orders", "OrderID");
            AddPrimaryKey("dbo.Inventory", "CarID");
            AddPrimaryKey("dbo.Customers", "CustID");
            AddPrimaryKey("dbo.CreditRisk", "CustID");
        }
    }
}
