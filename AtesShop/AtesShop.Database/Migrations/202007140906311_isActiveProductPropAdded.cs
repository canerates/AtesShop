namespace AtesShop.Database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class isActiveProductPropAdded : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Products", "isActive", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Products", "isActive");
        }
    }
}
