namespace SSWProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FixTables : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Agents", "Avatar_FileID", "dbo.Files");
            DropForeignKey("dbo.Files", "Agent_AgentID", "dbo.Agents");
            DropForeignKey("dbo.Files", "Customer_CustomerID", "dbo.Customers");
            DropIndex("dbo.Agents", new[] { "Avatar_FileID" });
            DropIndex("dbo.Files", new[] { "Agent_AgentID" });
            DropIndex("dbo.Files", new[] { "Customer_CustomerID" });
            
            DropColumn("dbo.Agents", "FileID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Agents", "Avatar_FileID", c => c.Int());
            AddColumn("dbo.Agents", "FileID", c => c.Int(nullable: false));
            DropForeignKey("dbo.Showings", "Listing_ListingID", "dbo.Listings");
            DropForeignKey("dbo.Files", "ListingID", "dbo.Listings");
            DropForeignKey("dbo.Files", "CustomerID", "dbo.Customers");
            DropForeignKey("dbo.Files", "AgentID", "dbo.Agents");
            DropIndex("dbo.Showings", new[] { "Listing_ListingID" });
            DropIndex("dbo.Files", new[] { "ListingID" });
            DropIndex("dbo.Files", new[] { "CustomerID" });
            DropIndex("dbo.Files", new[] { "AgentID" });
            AlterColumn("dbo.Showings", "Listing_ListingID", c => c.Int(nullable: false));
            AlterColumn("dbo.Files", "ListingID", c => c.Int());
            AlterColumn("dbo.Files", "CustomerID", c => c.Int());
            AlterColumn("dbo.Files", "AgentID", c => c.Int());
            CreateIndex("dbo.Showings", "Listing_ListingID");
            CreateIndex("dbo.Files", "Listing_ListingID");
            CreateIndex("dbo.Files", "Customer_CustomerID");
            CreateIndex("dbo.Files", "Agent_AgentID");
            CreateIndex("dbo.Agents", "Avatar_FileID");
            AddForeignKey("dbo.Showings", "Listing_ListingID", "dbo.Listings", "ListingID", cascadeDelete: true);
            AddForeignKey("dbo.Files", "Listing_ListingID", "dbo.Listings", "ListingID");
            AddForeignKey("dbo.Files", "Customer_CustomerID", "dbo.Customers", "CustomerID");
            AddForeignKey("dbo.Files", "Agent_AgentID", "dbo.Agents", "AgentID");
            AddForeignKey("dbo.Agents", "Avatar_FileID", "dbo.Files", "FileID");
        }
    }
}
