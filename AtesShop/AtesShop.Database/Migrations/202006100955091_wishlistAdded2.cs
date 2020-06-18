namespace AtesShop.Database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class wishlistAdded2 : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Wishes", newName: "Wishlists");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.Wishlists", newName: "Wishes");
        }
    }
}
