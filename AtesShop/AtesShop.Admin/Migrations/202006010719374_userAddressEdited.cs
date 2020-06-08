namespace AtesShop.Admin.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class userAddressEdited : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Users", "AddressId", "dbo.UserAddresses");
            DropIndex("dbo.Users", new[] { "AddressId" });
            AlterColumn("dbo.Users", "AddressId", c => c.Int());
            CreateIndex("dbo.Users", "AddressId");
            AddForeignKey("dbo.Users", "AddressId", "dbo.UserAddresses", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Users", "AddressId", "dbo.UserAddresses");
            DropIndex("dbo.Users", new[] { "AddressId" });
            AlterColumn("dbo.Users", "AddressId", c => c.Int(nullable: false));
            CreateIndex("dbo.Users", "AddressId");
            AddForeignKey("dbo.Users", "AddressId", "dbo.UserAddresses", "Id", cascadeDelete: true);
        }
    }
}
