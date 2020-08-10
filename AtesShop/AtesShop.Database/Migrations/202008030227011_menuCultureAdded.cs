namespace AtesShop.Database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class menuCultureAdded : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.MainMenus", "Culture", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.MainMenus", "Culture");
        }
    }
}
