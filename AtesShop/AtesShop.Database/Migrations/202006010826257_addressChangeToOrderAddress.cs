namespace AtesShop.Database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addressChangeToOrderAddress : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Addresses", newName: "OrderAddresses");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.OrderAddresses", newName: "Addresses");
        }
    }
}
