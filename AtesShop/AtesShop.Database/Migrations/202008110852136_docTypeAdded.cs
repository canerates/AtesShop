namespace AtesShop.Database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class docTypeAdded : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.DocFiles", "DocType", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.DocFiles", "DocType");
        }
    }
}
