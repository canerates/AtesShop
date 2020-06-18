namespace AtesShop.Database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class wishlistEdit2 : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Wishlists", new[] { "ProductId" });
            AlterColumn("dbo.Wishlists", "UserId", c => c.Guid(nullable: false));
            CreateIndex("dbo.Wishlists", new[] { "UserId", "ProductId" }, unique: true, name: "IX_UserIdAndProductId");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Wishlists", "IX_UserIdAndProductId");
            AlterColumn("dbo.Wishlists", "UserId", c => c.String());
            CreateIndex("dbo.Wishlists", "ProductId");
        }
    }
}
