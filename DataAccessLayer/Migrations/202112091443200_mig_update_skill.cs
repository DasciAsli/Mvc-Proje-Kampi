namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig_update_skill : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Skills", "ImageUrl");
            DropColumn("dbo.Skills", "Name");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Skills", "Name", c => c.String(maxLength: 50));
            AddColumn("dbo.Skills", "ImageUrl", c => c.String(maxLength: 150));
        }
    }
}
