namespace SSWProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddShowingTable1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Showings", "Listing_ListingID", c => c.Int(nullable: false));
            CreateIndex("dbo.Showings", "Listing_ListingID");
            AddForeignKey("dbo.Showings", "Listing_ListingID", "dbo.Listings", "ListingID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Showings", "Listing_ListingID", "dbo.Listings");
            DropIndex("dbo.Showings", new[] { "Listing_ListingID" });
            DropColumn("dbo.Showings", "Listing_ListingID");
        }
    }
}
