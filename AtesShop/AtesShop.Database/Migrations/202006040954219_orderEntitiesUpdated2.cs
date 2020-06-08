namespace AtesShop.Database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class orderEntitiesUpdated2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.OrderDetails", "AddressId", "dbo.OrderAddresses");
            DropForeignKey("dbo.Orders", "BillingDetailId", "dbo.OrderDetails");
            DropForeignKey("dbo.Orders", "ShippingDetailId", "dbo.OrderDetails");
            DropIndex("dbo.OrderDetails", new[] { "AddressId" });
            DropIndex("dbo.Orders", new[] { "BillingDetailId" });
            DropIndex("dbo.Orders", new[] { "ShippingDetailId" });
            AddColumn("dbo.OrderAddresses", "FirstName", c => c.String());
            AddColumn("dbo.OrderAddresses", "LastName", c => c.String());
            AddColumn("dbo.OrderAddresses", "CompanyName", c => c.String());
            AddColumn("dbo.OrderAddresses", "Email", c => c.String());
            AddColumn("dbo.OrderAddresses", "Phone", c => c.String());
            AddColumn("dbo.Orders", "BillingAddressId", c => c.Int(nullable: false));
            AddColumn("dbo.Orders", "ShippingAddressId", c => c.Int());
            AddColumn("dbo.UserAddresses", "CompanyName", c => c.String());
            AddColumn("dbo.UserAddresses", "Email", c => c.String());
            CreateIndex("dbo.Orders", "BillingAddressId");
            CreateIndex("dbo.Orders", "ShippingAddressId");
            AddForeignKey("dbo.Orders", "BillingAddressId", "dbo.OrderAddresses", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Orders", "ShippingAddressId", "dbo.OrderAddresses", "Id");
            DropColumn("dbo.Orders", "BillingDetailId");
            DropColumn("dbo.Orders", "ShippingDetailId");
            DropTable("dbo.OrderDetails");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.OrderDetails",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        CompanyName = c.String(),
                        Email = c.String(),
                        Phone = c.String(),
                        AddressId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Orders", "ShippingDetailId", c => c.Int());
            AddColumn("dbo.Orders", "BillingDetailId", c => c.Int(nullable: false));
            DropForeignKey("dbo.Orders", "ShippingAddressId", "dbo.OrderAddresses");
            DropForeignKey("dbo.Orders", "BillingAddressId", "dbo.OrderAddresses");
            DropIndex("dbo.Orders", new[] { "ShippingAddressId" });
            DropIndex("dbo.Orders", new[] { "BillingAddressId" });
            DropColumn("dbo.UserAddresses", "Email");
            DropColumn("dbo.UserAddresses", "CompanyName");
            DropColumn("dbo.Orders", "ShippingAddressId");
            DropColumn("dbo.Orders", "BillingAddressId");
            DropColumn("dbo.OrderAddresses", "Phone");
            DropColumn("dbo.OrderAddresses", "Email");
            DropColumn("dbo.OrderAddresses", "CompanyName");
            DropColumn("dbo.OrderAddresses", "LastName");
            DropColumn("dbo.OrderAddresses", "FirstName");
            CreateIndex("dbo.Orders", "ShippingDetailId");
            CreateIndex("dbo.Orders", "BillingDetailId");
            CreateIndex("dbo.OrderDetails", "AddressId");
            AddForeignKey("dbo.Orders", "ShippingDetailId", "dbo.OrderDetails", "Id");
            AddForeignKey("dbo.Orders", "BillingDetailId", "dbo.OrderDetails", "Id", cascadeDelete: true);
            AddForeignKey("dbo.OrderDetails", "AddressId", "dbo.OrderAddresses", "Id", cascadeDelete: true);
        }
    }
}
