namespace AtesShop.Database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class orderByAdded : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ProductAttributes", "OrderId", c => c.Int(nullable: false));
            AddColumn("dbo.ProductFeatures", "OrderId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.ProductFeatures", "OrderId");
            DropColumn("dbo.ProductAttributes", "OrderId");
        }
    }
}
