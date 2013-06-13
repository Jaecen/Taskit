namespace Taskit.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AttributeSortOrder : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Attributes", "DisplayOrder", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Attributes", "DisplayOrder");
        }
    }
}
