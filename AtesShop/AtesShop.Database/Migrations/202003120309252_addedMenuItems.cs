namespace AtesShop.Database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedMenuItems : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.MainMenus",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Url = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.SubMenus",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Url = c.String(),
                        MainMenu_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.MainMenus", t => t.MainMenu_Id)
                .Index(t => t.MainMenu_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SubMenus", "MainMenu_Id", "dbo.MainMenus");
            DropIndex("dbo.SubMenus", new[] { "MainMenu_Id" });
            DropTable("dbo.SubMenus");
            DropTable("dbo.MainMenus");
        }
    }
}
