namespace AtesShop.Database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class isSetPropAdded : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Products", "isSet", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Products", "isSet");
        }
    }
}
