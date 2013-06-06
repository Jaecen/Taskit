namespace Taskit.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialSetup : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.People",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Cards",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Attributes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Key = c.String(),
                        Value = c.String(),
                        Card_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Cards", t => t.Card_Id)
                .Index(t => t.Card_Id);
            
            CreateTable(
                "dbo.CardPersons",
                c => new
                    {
                        Card_Id = c.Int(nullable: false),
                        Person_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Card_Id, t.Person_Id })
                .ForeignKey("dbo.Cards", t => t.Card_Id, cascadeDelete: true)
                .ForeignKey("dbo.People", t => t.Person_Id, cascadeDelete: true)
                .Index(t => t.Card_Id)
                .Index(t => t.Person_Id);
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.CardPersons", new[] { "Person_Id" });
            DropIndex("dbo.CardPersons", new[] { "Card_Id" });
            DropIndex("dbo.Attributes", new[] { "Card_Id" });
            DropForeignKey("dbo.CardPersons", "Person_Id", "dbo.People");
            DropForeignKey("dbo.CardPersons", "Card_Id", "dbo.Cards");
            DropForeignKey("dbo.Attributes", "Card_Id", "dbo.Cards");
            DropTable("dbo.CardPersons");
            DropTable("dbo.Attributes");
            DropTable("dbo.Cards");
            DropTable("dbo.People");
        }
    }
}
