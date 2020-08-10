namespace AtesShop.Database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class isHiddenAdded : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Products", "isHidden", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Products", "isHidden");
        }
    }
}
