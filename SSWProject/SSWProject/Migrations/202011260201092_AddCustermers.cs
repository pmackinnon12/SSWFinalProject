namespace SSWProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCustermers : DbMigration
    {
        public override void Up()
        {
            DropTable("dbo.Showings");
            DropTable("dbo.Listings");
            DropTable("dbo.Customers");
            CreateTable(
                "dbo.CustomerFiles",
                c => new
                    {
                        FileID = c.Int(nullable: false, identity: true),
                        FileName = c.String(),
                        ContentType = c.String(),
                        Content = c.Binary(),
                        FileType = c.Int(nullable: false),
                        CustomerID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.FileID)
                .ForeignKey("dbo.Customers", t => t.CustomerID, cascadeDelete: true)
                .Index(t => t.CustomerID);
            
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
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CustomerFiles", "CustomerID", "dbo.Customers");
            DropIndex("dbo.CustomerFiles", new[] { "CustomerID" });
            DropTable("dbo.Customers");
            DropTable("dbo.CustomerFiles");
        }
    }
}
