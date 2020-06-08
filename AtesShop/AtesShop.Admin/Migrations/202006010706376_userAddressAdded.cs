namespace AtesShop.Admin.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class userAddressAdded : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.UserAddresses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Country = c.String(),
                        State = c.String(),
                        City = c.String(),
                        ZipCode = c.String(),
                        Line1 = c.String(),
                        Line2 = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Users", "AddressId", c => c.Int(nullable: true));
            CreateIndex("dbo.Users", "AddressId");
            AddForeignKey("dbo.Users", "AddressId", "dbo.UserAddresses", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Users", "AddressId", "dbo.UserAddresses");
            DropIndex("dbo.Users", new[] { "AddressId" });
            DropColumn("dbo.Users", "AddressId");
            DropTable("dbo.UserAddresses");
        }
    }
}
