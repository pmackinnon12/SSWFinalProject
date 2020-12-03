namespace SSWProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddFileTables6 : DbMigration
    {
        public override void Up()
        {
            
            DropIndex("dbo.Files", new[] { "CustomerID" });

            DropForeignKey("dbo.Files", "CustomerID", "dbo.Customers");
            RenameTable(name: "dbo.Files", newName: "AgentFiles");
            
            DropColumn("dbo.AgentFiles", "CustomerID");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        CustomerID = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false, maxLength: 25),
                        MiddleName = c.String(maxLength: 25),
                        LastName = c.String(nullable: false, maxLength: 25),
                        StreetAddress = c.String(nullable: false, maxLength: 50),
                        Municipality = c.String(nullable: false, maxLength: 50),
                        Province = c.String(nullable: false, maxLength: 50),
                        PostalCode = c.String(nullable: false, maxLength: 6),
                        HomePhone = c.String(nullable: false, maxLength: 10),
                        CellPhone = c.String(maxLength: 10),
                        DOB = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.CustomerID);
            
            AddColumn("dbo.AgentFiles", "CustomerID", c => c.Int(nullable: false));
            CreateIndex("dbo.AgentFiles", "CustomerID");
            AddForeignKey("dbo.Files", "CustomerID", "dbo.Customers", "CustomerID", cascadeDelete: true);
            RenameTable(name: "dbo.AgentFiles", newName: "Files");
        }
    }
}
