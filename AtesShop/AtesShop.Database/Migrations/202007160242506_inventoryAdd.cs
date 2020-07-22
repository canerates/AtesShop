namespace AtesShop.Database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class inventoryAdd : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Inventory",
                c => new
                    {
                        ProductId = c.Int(nullable: false),
                        Total = c.Int(nullable: false),
                        Available = c.Int(nullable: false),
                        Allocation = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ProductId)
                .ForeignKey("dbo.Products", t => t.ProductId)
                .Index(t => t.ProductId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Inventory", "ProductId", "dbo.Products");
            DropIndex("dbo.Inventory", new[] { "ProductId" });
            DropTable("dbo.Inventory");
        }
    }
}
