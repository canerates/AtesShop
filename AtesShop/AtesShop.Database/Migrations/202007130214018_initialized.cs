namespace AtesShop.Database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initialized : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AttributeSections",
                c => new
                    {
                        AttributeSectionId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.AttributeSectionId);
            
            CreateTable(
                "dbo.AttributeTypes",
                c => new
                    {
                        AttributeTypeId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.AttributeTypeId);
            
            CreateTable(
                "dbo.AttributeValues",
                c => new
                    {
                        AttributeValueId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.AttributeValueId);
            
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
                        FileIdList = c.String(),
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
                "dbo.ProductAttributes",
                c => new
                    {
                        ProductAttributeId = c.Int(nullable: false, identity: true),
                        ProductId = c.Int(nullable: false),
                        AttributeSectionId = c.Int(nullable: false),
                        AttributeTypeId = c.Int(nullable: false),
                        AttributeValueId = c.Int(nullable: false),
                        OrderId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ProductAttributeId)
                .ForeignKey("dbo.AttributeSections", t => t.AttributeSectionId, cascadeDelete: true)
                .ForeignKey("dbo.AttributeTypes", t => t.AttributeTypeId, cascadeDelete: true)
                .ForeignKey("dbo.AttributeValues", t => t.AttributeValueId, cascadeDelete: true)
                .ForeignKey("dbo.Products", t => t.ProductId, cascadeDelete: true)
                .Index(t => t.ProductId)
                .Index(t => t.AttributeSectionId)
                .Index(t => t.AttributeTypeId)
                .Index(t => t.AttributeValueId);
            
            CreateTable(
                "dbo.Ratings",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Rate = c.Int(nullable: false),
                        IpAddress = c.String(),
                        ProductId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Products", t => t.ProductId, cascadeDelete: true)
                .Index(t => t.ProductId);
            
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
                "dbo.DocFiles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        ContentType = c.String(),
                        Data = c.Binary(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Features",
                c => new
                    {
                        FeatureId = c.Int(nullable: false, identity: true),
                        FeatureValue = c.String(),
                    })
                .PrimaryKey(t => t.FeatureId);
            
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
                "dbo.OrderAddresses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        CompanyName = c.String(),
                        Email = c.String(),
                        Phone = c.String(),
                        Country = c.String(),
                        State = c.String(),
                        City = c.String(),
                        ZipCode = c.String(),
                        Line1 = c.String(),
                        Line2 = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.OrderItems",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Quantity = c.Int(nullable: false),
                        OrderId = c.Int(nullable: false),
                        ProductId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Orders", t => t.OrderId, cascadeDelete: true)
                .ForeignKey("dbo.Products", t => t.ProductId, cascadeDelete: true)
                .Index(t => t.OrderId)
                .Index(t => t.ProductId);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(),
                        BillingAddressId = c.Int(nullable: false),
                        ShippingAddressId = c.Int(),
                        Date = c.DateTime(nullable: false),
                        Status = c.String(),
                        PaymentType = c.String(),
                        TotalPrice = c.String(),
                        OrderNote = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.OrderAddresses", t => t.BillingAddressId, cascadeDelete: true)
                .ForeignKey("dbo.OrderAddresses", t => t.ShippingAddressId)
                .Index(t => t.BillingAddressId)
                .Index(t => t.ShippingAddressId);
            
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
                "dbo.ProductFeatures",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FeatureId = c.Int(nullable: false),
                        ProductId = c.Int(nullable: false),
                        OrderId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Features", t => t.FeatureId, cascadeDelete: true)
                .ForeignKey("dbo.Products", t => t.ProductId, cascadeDelete: true)
                .Index(t => t.FeatureId)
                .Index(t => t.ProductId);
            
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
            
            CreateTable(
                "dbo.UserAddresses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(),
                        FirstName = c.String(),
                        LastName = c.String(),
                        CompanyName = c.String(),
                        Email = c.String(),
                        Phone = c.String(),
                        Country = c.String(),
                        State = c.String(),
                        City = c.String(),
                        ZipCode = c.String(),
                        Line1 = c.String(),
                        Line2 = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Wishlists",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.Guid(nullable: false),
                        ProductId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Products", t => t.ProductId, cascadeDelete: true)
                .Index(t => new { t.UserId, t.ProductId }, unique: true, name: "IX_UserIdAndProductId");
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Wishlists", "ProductId", "dbo.Products");
            DropForeignKey("dbo.ProductKeys", "ProductId", "dbo.Products");
            DropForeignKey("dbo.ProductFeatures", "ProductId", "dbo.Products");
            DropForeignKey("dbo.ProductFeatures", "FeatureId", "dbo.Features");
            DropForeignKey("dbo.OrderItems", "ProductId", "dbo.Products");
            DropForeignKey("dbo.OrderItems", "OrderId", "dbo.Orders");
            DropForeignKey("dbo.Orders", "ShippingAddressId", "dbo.OrderAddresses");
            DropForeignKey("dbo.Orders", "BillingAddressId", "dbo.OrderAddresses");
            DropForeignKey("dbo.SubMenus", "MainMenuId", "dbo.MainMenus");
            DropForeignKey("dbo.CategoryKeys", "CategoryId", "dbo.Categories");
            DropForeignKey("dbo.Ratings", "ProductId", "dbo.Products");
            DropForeignKey("dbo.Products", "CategoryId", "dbo.Categories");
            DropForeignKey("dbo.ProductAttributes", "ProductId", "dbo.Products");
            DropForeignKey("dbo.ProductAttributes", "AttributeValueId", "dbo.AttributeValues");
            DropForeignKey("dbo.ProductAttributes", "AttributeTypeId", "dbo.AttributeTypes");
            DropForeignKey("dbo.ProductAttributes", "AttributeSectionId", "dbo.AttributeSections");
            DropIndex("dbo.Wishlists", "IX_UserIdAndProductId");
            DropIndex("dbo.ProductKeys", new[] { "ProductId" });
            DropIndex("dbo.ProductFeatures", new[] { "ProductId" });
            DropIndex("dbo.ProductFeatures", new[] { "FeatureId" });
            DropIndex("dbo.Orders", new[] { "ShippingAddressId" });
            DropIndex("dbo.Orders", new[] { "BillingAddressId" });
            DropIndex("dbo.OrderItems", new[] { "ProductId" });
            DropIndex("dbo.OrderItems", new[] { "OrderId" });
            DropIndex("dbo.SubMenus", new[] { "MainMenuId" });
            DropIndex("dbo.CategoryKeys", new[] { "CategoryId" });
            DropIndex("dbo.Ratings", new[] { "ProductId" });
            DropIndex("dbo.ProductAttributes", new[] { "AttributeValueId" });
            DropIndex("dbo.ProductAttributes", new[] { "AttributeTypeId" });
            DropIndex("dbo.ProductAttributes", new[] { "AttributeSectionId" });
            DropIndex("dbo.ProductAttributes", new[] { "ProductId" });
            DropIndex("dbo.Products", new[] { "CategoryId" });
            DropTable("dbo.Wishlists");
            DropTable("dbo.UserAddresses");
            DropTable("dbo.Resources");
            DropTable("dbo.ProductKeys");
            DropTable("dbo.ProductFeatures");
            DropTable("dbo.Prices");
            DropTable("dbo.Orders");
            DropTable("dbo.OrderItems");
            DropTable("dbo.OrderAddresses");
            DropTable("dbo.SubMenus");
            DropTable("dbo.MainMenus");
            DropTable("dbo.Images");
            DropTable("dbo.Features");
            DropTable("dbo.DocFiles");
            DropTable("dbo.CategoryKeys");
            DropTable("dbo.Ratings");
            DropTable("dbo.ProductAttributes");
            DropTable("dbo.Products");
            DropTable("dbo.Categories");
            DropTable("dbo.AttributeValues");
            DropTable("dbo.AttributeTypes");
            DropTable("dbo.AttributeSections");
        }
    }
}
