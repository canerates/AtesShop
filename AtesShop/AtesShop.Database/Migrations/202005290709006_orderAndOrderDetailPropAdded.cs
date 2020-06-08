namespace AtesShop.Database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class orderAndOrderDetailPropAdded : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.OrderDetails", "Email", c => c.String());
            AddColumn("dbo.OrderDetails", "Phone", c => c.String());
            AddColumn("dbo.Orders", "UserId", c => c.String());
            AddColumn("dbo.Orders", "PaymentType", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Orders", "PaymentType");
            DropColumn("dbo.Orders", "UserId");
            DropColumn("dbo.OrderDetails", "Phone");
            DropColumn("dbo.OrderDetails", "Email");
        }
    }
}
