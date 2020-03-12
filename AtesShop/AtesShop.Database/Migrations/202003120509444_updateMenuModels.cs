namespace AtesShop.Database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateMenuModels : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.MainMenus", "ActionName", c => c.String());
            AddColumn("dbo.MainMenus", "ControllerName", c => c.Int(nullable: false));
            AddColumn("dbo.SubMenus", "ActionName", c => c.String());
            AddColumn("dbo.SubMenus", "ControllerName", c => c.Int(nullable: false));
            AddColumn("dbo.SubMenus", "ParameterId", c => c.Int(nullable: false));
            DropColumn("dbo.MainMenus", "Url");
            DropColumn("dbo.SubMenus", "Url");
        }
        
        public override void Down()
        {
            AddColumn("dbo.SubMenus", "Url", c => c.String());
            AddColumn("dbo.MainMenus", "Url", c => c.String());
            DropColumn("dbo.SubMenus", "ParameterId");
            DropColumn("dbo.SubMenus", "ControllerName");
            DropColumn("dbo.SubMenus", "ActionName");
            DropColumn("dbo.MainMenus", "ControllerName");
            DropColumn("dbo.MainMenus", "ActionName");
        }
    }
}
