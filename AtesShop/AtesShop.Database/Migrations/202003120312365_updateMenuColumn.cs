namespace AtesShop.Database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateMenuColumn : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.SubMenus", "MainMenu_Id", "dbo.MainMenus");
            DropIndex("dbo.SubMenus", new[] { "MainMenu_Id" });
            RenameColumn(table: "dbo.SubMenus", name: "MainMenu_Id", newName: "MainMenuId");
            AlterColumn("dbo.SubMenus", "MainMenuId", c => c.Int(nullable: false));
            CreateIndex("dbo.SubMenus", "MainMenuId");
            AddForeignKey("dbo.SubMenus", "MainMenuId", "dbo.MainMenus", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SubMenus", "MainMenuId", "dbo.MainMenus");
            DropIndex("dbo.SubMenus", new[] { "MainMenuId" });
            AlterColumn("dbo.SubMenus", "MainMenuId", c => c.Int());
            RenameColumn(table: "dbo.SubMenus", name: "MainMenuId", newName: "MainMenu_Id");
            CreateIndex("dbo.SubMenus", "MainMenu_Id");
            AddForeignKey("dbo.SubMenus", "MainMenu_Id", "dbo.MainMenus", "Id");
        }
    }
}
