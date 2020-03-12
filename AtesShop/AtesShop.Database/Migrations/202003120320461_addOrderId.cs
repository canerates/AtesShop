namespace AtesShop.Database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addOrderId : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.MainMenus", "OrderId", c => c.Int(nullable: false));
            AddColumn("dbo.SubMenus", "OrderId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.SubMenus", "OrderId");
            DropColumn("dbo.MainMenus", "OrderId");
        }
    }
}
