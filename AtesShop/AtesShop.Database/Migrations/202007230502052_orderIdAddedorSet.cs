namespace AtesShop.Database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class orderIdAddedorSet : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ProductSetItems", "OrderId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.ProductSetItems", "OrderId");
        }
    }
}
