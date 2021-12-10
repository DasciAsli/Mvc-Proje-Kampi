namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig_istrash : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Messages", "isTrash", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Messages", "isTrash");
        }
    }
}
