namespace AtesShop.Admin.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class userAddressEdited2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Users", "AddressId", "dbo.UserAddresses");
            DropIndex("dbo.Users", new[] { "AddressId" });
            AddColumn("dbo.UserAddresses", "UserId", c => c.String(maxLength: 128));
            CreateIndex("dbo.UserAddresses", "UserId");
            AddForeignKey("dbo.UserAddresses", "UserId", "dbo.Users", "Id");
            DropColumn("dbo.Users", "AddressId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Users", "AddressId", c => c.Int());
            DropForeignKey("dbo.UserAddresses", "UserId", "dbo.Users");
            DropIndex("dbo.UserAddresses", new[] { "UserId" });
            DropColumn("dbo.UserAddresses", "UserId");
            CreateIndex("dbo.Users", "AddressId");
            AddForeignKey("dbo.Users", "AddressId", "dbo.UserAddresses", "Id");
        }
    }
}
