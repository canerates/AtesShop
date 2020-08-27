namespace AtesShop.Database.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class orderIdSeedReset : DbMigration
    {
        public override void Up()
        {
            Sql("DBCC CHECKIDENT ('Orders', RESEED, 2456)");
        }
        
        public override void Down()
        {
        }
    }
}
