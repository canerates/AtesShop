namespace AtesShop.Database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class orderPropUpdated : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Orders", "TrackingId", c => c.String());
            AddColumn("dbo.Orders", "OrderId", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Orders", "OrderId");
            DropColumn("dbo.Orders", "TrackingId");
        }
    }
}
