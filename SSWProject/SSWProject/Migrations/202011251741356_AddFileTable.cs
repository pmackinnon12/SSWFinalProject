namespace SSWProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddFileTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Files",
                c => new
                {
                    FileID = c.Int(nullable: false, identity: true),
                    FileName = c.String(),
                    ContentType = c.String(),
                    Content = c.Binary(),
                    FileType = c.Int(nullable: false),
                    CustomerID = c.Int(nullable: false),
                    AgentID = c.Int(nullable: false),
                })
                .PrimaryKey(t => t.FileID)
                .ForeignKey("dbo.Agents", t => t.AgentID, cascadeDelete: true)
                .ForeignKey("dbo.Customers", t => t.CustomerID, cascadeDelete: true)
                .Index(t => t.CustomerID)
                .Index(t => t.AgentID);
        }
        
        public override void Down()
        {
        }
    }
}
