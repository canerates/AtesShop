namespace AtesShop.Database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initialized : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                        ImageIdList = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        CategoryId = c.Int(nullable: false),
                        ImageIdList = c.String(),
                        isFeatured = c.Boolean(nullable: false),
                        isNew = c.Boolean(nullable: false),
                        isTopRated = c.Boolean(nullable: false),
                        isBestSeller = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Categories", t => t.CategoryId, cascadeDelete: true)
                .Index(t => t.CategoryId);
            
            CreateTable(
                "dbo.CategoryTranslations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CategoryNameResourceKey = c.String(),
                        CategoryDescriptionResourceKey = c.String(),
                        CategoryId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Categories", t => t.CategoryId, cascadeDelete: true)
                .Index(t => t.CategoryId);
            
            CreateTable(
                "dbo.Images",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        ContentType = c.String(),
                        Data = c.Binary(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.MainMenus",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        ActionName = c.String(),
                        ControllerName = c.String(),
                        OrderId = c.Int(nullable: false),
                        ResourceKey = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.SubMenus",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        ActionName = c.String(),
                        ControllerName = c.String(),
                        ParameterId = c.Int(nullable: false),
                        OrderId = c.Int(nullable: false),
                        MainMenuId = c.Int(nullable: false),
                        ResourceKey = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.MainMenus", t => t.MainMenuId, cascadeDelete: true)
                .Index(t => t.MainMenuId);
            
            CreateTable(
                "dbo.ProductTranslations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ProductNameResourceKey = c.String(),
                        ProductDescriptionResourceKey = c.String(),
                        ProductPriceResourceKey = c.String(),
                        ProductId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Products", t => t.ProductId, cascadeDelete: true)
                .Index(t => t.ProductId);
            
            CreateTable(
                "dbo.Resources",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Key = c.String(),
                        Value = c.String(),
                        Culture = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ProductTranslations", "ProductId", "dbo.Products");
            DropForeignKey("dbo.SubMenus", "MainMenuId", "dbo.MainMenus");
            DropForeignKey("dbo.CategoryTranslations", "CategoryId", "dbo.Categories");
            DropForeignKey("dbo.Products", "CategoryId", "dbo.Categories");
            DropIndex("dbo.ProductTranslations", new[] { "ProductId" });
            DropIndex("dbo.SubMenus", new[] { "MainMenuId" });
            DropIndex("dbo.CategoryTranslations", new[] { "CategoryId" });
            DropIndex("dbo.Products", new[] { "CategoryId" });
            DropTable("dbo.Resources");
            DropTable("dbo.ProductTranslations");
            DropTable("dbo.SubMenus");
            DropTable("dbo.MainMenus");
            DropTable("dbo.Images");
            DropTable("dbo.CategoryTranslations");
            DropTable("dbo.Products");
            DropTable("dbo.Categories");
        }
    }
}
