namespace AtesShop.Database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class setItemPropAdded : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ProductSetItems", "isOptional", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.ProductSetItems", "isOptional");
        }
    }
}
