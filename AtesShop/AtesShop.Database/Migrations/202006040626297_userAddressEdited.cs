namespace AtesShop.Database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class userAddressEdited : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.UserAddresses", "FirstName", c => c.String());
            AddColumn("dbo.UserAddresses", "LastName", c => c.String());
            AddColumn("dbo.UserAddresses", "Phone", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.UserAddresses", "Phone");
            DropColumn("dbo.UserAddresses", "LastName");
            DropColumn("dbo.UserAddresses", "FirstName");
        }
    }
}
