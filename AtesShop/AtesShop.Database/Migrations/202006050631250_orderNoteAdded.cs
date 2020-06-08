namespace AtesShop.Database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class orderNoteAdded : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Orders", "OrderNote", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Orders", "OrderNote");
        }
    }
}
