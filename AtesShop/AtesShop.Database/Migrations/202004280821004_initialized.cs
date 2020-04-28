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
                        Price = c.String(),
                        PrePrice = c.String(),
                        CategoryId = c.Int(nullable: false),
                        ImageIdList = c.String(),
                        isDiscount = c.Boolean(nullable: false),
                        isFeatured = c.Boolean(nullable: false),
                        isNew = c.Boolean(nullable: false),
                        isTopRated = c.Boolean(nullable: false),
                        isBestSeller = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Categories", t => t.CategoryId, cascadeDelete: true)
                .Index(t => t.CategoryId);
            
            CreateTable(
                "dbo.CategoryKeys",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        NameKey = c.String(),
                        DescriptionKey = c.String(),
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
                "dbo.Prices",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Key = c.String(),
                        Value = c.String(),
                        PreValue = c.String(),
                        Culture = c.String(),
                        RoleId = c.String(),
                        RoleName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ProductKeys",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        NameKey = c.String(),
                        DescriptionKey = c.String(),
                        PriceKey = c.String(),
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
            DropForeignKey("dbo.ProductKeys", "ProductId", "dbo.Products");
            DropForeignKey("dbo.SubMenus", "MainMenuId", "dbo.MainMenus");
            DropForeignKey("dbo.CategoryKeys", "CategoryId", "dbo.Categories");
            DropForeignKey("dbo.Products", "CategoryId", "dbo.Categories");
            DropIndex("dbo.ProductKeys", new[] { "ProductId" });
            DropIndex("dbo.SubMenus", new[] { "MainMenuId" });
            DropIndex("dbo.CategoryKeys", new[] { "CategoryId" });
            DropIndex("dbo.Products", new[] { "CategoryId" });
            DropTable("dbo.Resources");
            DropTable("dbo.ProductKeys");
            DropTable("dbo.Prices");
            DropTable("dbo.SubMenus");
            DropTable("dbo.MainMenus");
            DropTable("dbo.Images");
            DropTable("dbo.CategoryKeys");
            DropTable("dbo.Products");
            DropTable("dbo.Categories");
        }
    }
}
