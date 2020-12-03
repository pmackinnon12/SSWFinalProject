namespace SSWProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddListingTable1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ListingFiles",
                c => new
                    {
                        FileID = c.Int(nullable: false, identity: true),
                        FileName = c.String(),
                        ContentType = c.String(),
                        Content = c.Binary(),
                        FileType = c.Int(nullable: false),
                        ListingID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.FileID)
                .ForeignKey("dbo.Listings", t => t.ListingID, cascadeDelete: true)
                .Index(t => t.ListingID);
            
            CreateTable(
                "dbo.Listings",
                c => new
                    {
                        ListingID = c.Int(nullable: false, identity: true),
                        AgentID = c.Int(nullable: false),
                        CustomerID = c.Int(nullable: false),
                        StreetAddress = c.String(nullable: false, maxLength: 25),
                        PostalCode = c.String(nullable: false, maxLength: 10),
                        Municipality = c.String(nullable: false, maxLength: 50),
                        AreaOfCity = c.String(nullable: false, maxLength: 25),
                        NumberOfStories = c.Int(nullable: false),
                        NumberOfBeds = c.Int(nullable: false),
                        NumberOfBaths = c.Int(nullable: false),
                        Summary = c.String(nullable: false),
                        TypeOfHeating = c.String(nullable: false, maxLength: 25),
                        IsContractSigned = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ListingID)
                .ForeignKey("dbo.Agents", t => t.AgentID, cascadeDelete: true)
                .ForeignKey("dbo.Customers", t => t.CustomerID, cascadeDelete: true)
                .Index(t => t.AgentID)
                .Index(t => t.CustomerID);
            
            CreateTable(
                "dbo.Showings",
                c => new
                    {
                        ShowingID = c.Int(nullable: false, identity: true),
                        LisitngID = c.Int(nullable: false),
                        ShowingDate = c.DateTime(nullable: false),
                        StartTime = c.DateTime(nullable: false),
                        EndTime = c.DateTime(nullable: false),
                        Listing_ListingID = c.Int(),
                    })
                .PrimaryKey(t => t.ShowingID)
                .ForeignKey("dbo.Listings", t => t.Listing_ListingID)
                .Index(t => t.Listing_ListingID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Showings", "Listing_ListingID", "dbo.Listings");
            DropForeignKey("dbo.ListingFiles", "ListingID", "dbo.Listings");
            DropForeignKey("dbo.Listings", "CustomerID", "dbo.Customers");
            DropForeignKey("dbo.Listings", "AgentID", "dbo.Agents");
            DropIndex("dbo.Showings", new[] { "Listing_ListingID" });
            DropIndex("dbo.Listings", new[] { "CustomerID" });
            DropIndex("dbo.Listings", new[] { "AgentID" });
            DropIndex("dbo.ListingFiles", new[] { "ListingID" });
            DropTable("dbo.Showings");
            DropTable("dbo.Listings");
            DropTable("dbo.ListingFiles");
        }
    }
}
