namespace SSWProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FixListingTypo : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Showings", "Listing_ListingID", "dbo.Listings");
            DropIndex("dbo.Showings", new[] { "Listing_ListingID" });
            RenameColumn(table: "dbo.Showings", name: "Listing_ListingID", newName: "ListingID");
            AlterColumn("dbo.Showings", "ListingID", c => c.Int(nullable: false));
            CreateIndex("dbo.Showings", "ListingID");
            AddForeignKey("dbo.Showings", "ListingID", "dbo.Listings", "ListingID", cascadeDelete: true);
            DropColumn("dbo.Showings", "LisitngID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Showings", "LisitngID", c => c.Int(nullable: false));
            DropForeignKey("dbo.Showings", "ListingID", "dbo.Listings");
            DropIndex("dbo.Showings", new[] { "ListingID" });
            AlterColumn("dbo.Showings", "ListingID", c => c.Int());
            RenameColumn(table: "dbo.Showings", name: "ListingID", newName: "Listing_ListingID");
            CreateIndex("dbo.Showings", "Listing_ListingID");
            AddForeignKey("dbo.Showings", "Listing_ListingID", "dbo.Listings", "ListingID");
        }
    }
}
