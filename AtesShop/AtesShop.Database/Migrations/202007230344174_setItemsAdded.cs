namespace AtesShop.Database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class setItemsAdded : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ProductSetItems",
                c => new
                    {
                        ItemId = c.Int(nullable: false, identity: true),
                        ProductSetId = c.Int(nullable: false),
                        ItemProductID = c.Int(nullable: false),
                        ItemProductName = c.String(),
                        ItemProductDescription = c.String(),
                        ItemProductQuantity = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ItemId)
                .ForeignKey("dbo.Products", t => t.ProductSetId, cascadeDelete: true)
                .Index(t => t.ProductSetId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ProductSetItems", "ProductSetId", "dbo.Products");
            DropIndex("dbo.ProductSetItems", new[] { "ProductSetId" });
            DropTable("dbo.ProductSetItems");
        }
    }
}
