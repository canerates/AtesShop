namespace AtesShop.Database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateMenuModels2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.MainMenus", "ControllerName", c => c.String());
            AlterColumn("dbo.SubMenus", "ControllerName", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.SubMenus", "ControllerName", c => c.Int(nullable: false));
            AlterColumn("dbo.MainMenus", "ControllerName", c => c.Int(nullable: false));
        }
    }
}
