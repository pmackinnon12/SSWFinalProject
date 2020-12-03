namespace SSWProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddListingTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Listings",
                c => new
                    {
                        ListingID = c.Int(nullable: false, identity: true),
                        AgentID = c.Int(nullable: false),
                        CustomerID = c.Int(nullable: false),
                        StreetAddress = c.String(),
                        Municipality = c.String(),
                        PostalCode = c.String(),
                        ProvinceOrState = c.String(),
                        SquareFootage = c.Int(nullable: false),
                        NumberOfBeds = c.Int(nullable: false),
                        NumberOfBaths = c.Int(nullable: false),
                        NumberOfStories = c.Int(nullable: false),
                        AreaOfCity = c.String(),
                        Summary = c.String(),
                        TypeOfHeating = c.String(),
                        SpecialFeatures = c.String(),
                        SalesPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        IsContractSigned = c.Boolean(nullable: false),
                        ContractStartDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ListingID)
                .ForeignKey("dbo.Agents", t => t.AgentID, cascadeDelete: true)
                .ForeignKey("dbo.Customers", t => t.CustomerID, cascadeDelete: true)
                .Index(t => t.AgentID)
                .Index(t => t.CustomerID);
            
            AddColumn("dbo.Files", "Listing_ListingID", c => c.Int());
            CreateIndex("dbo.Files", "Listing_ListingID");
            AddForeignKey("dbo.Files", "Listing_ListingID", "dbo.Listings", "ListingID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Files", "Listing_ListingID", "dbo.Listings");
            DropForeignKey("dbo.Listings", "CustomerID", "dbo.Customers");
            DropForeignKey("dbo.Listings", "AgentID", "dbo.Agents");
            DropIndex("dbo.Listings", new[] { "CustomerID" });
            DropIndex("dbo.Listings", new[] { "AgentID" });
            DropIndex("dbo.Files", new[] { "Listing_ListingID" });
            DropColumn("dbo.Files", "Listing_ListingID");
            DropTable("dbo.Listings");
        }
    }
}
