namespace AtesShop.Admin.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class userAddressEdited3 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.UserAddresses", "UserId", "dbo.Users");
            DropIndex("dbo.UserAddresses", new[] { "UserId" });
            DropTable("dbo.UserAddresses");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.UserAddresses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(maxLength: 128),
                        Country = c.String(),
                        State = c.String(),
                        City = c.String(),
                        ZipCode = c.String(),
                        Line1 = c.String(),
                        Line2 = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateIndex("dbo.UserAddresses", "UserId");
            AddForeignKey("dbo.UserAddresses", "UserId", "dbo.Users", "Id");
        }
    }
}
