namespace ShoppingLot.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        CategoryID = c.Int(nullable: false),
                        CatName = c.String(maxLength: 20, fixedLength: true),
                    })
                .PrimaryKey(t => t.CategoryID);
            
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        CustID = c.Int(nullable: false),
                        CustName = c.String(maxLength: 30, fixedLength: true),
                        CustLastName = c.String(maxLength: 30, fixedLength: true),
                        GoodsID = c.Int(),
                        GoodsNum = c.Int(),
                    })
                .PrimaryKey(t => t.CustID);
            
            CreateTable(
                "dbo.Store",
                c => new
                    {
                        GoodsID = c.Int(nullable: false),
                        Remain = c.Int(nullable: false),
                        Cost = c.Int(nullable: false),
                        Name = c.String(maxLength: 30, fixedLength: true),
                        Category = c.String(maxLength: 30, fixedLength: true),
                        Description = c.String(maxLength: 100, fixedLength: true),
                    })
                .PrimaryKey(t => t.GoodsID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Store");
            DropTable("dbo.Customers");
            DropTable("dbo.Categories");
        }
    }
}
