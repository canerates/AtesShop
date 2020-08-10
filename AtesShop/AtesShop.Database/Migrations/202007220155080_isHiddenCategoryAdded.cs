namespace AtesShop.Database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class isHiddenCategoryAdded : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Categories", "isHidden", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Categories", "isHidden");
        }
    }
}
