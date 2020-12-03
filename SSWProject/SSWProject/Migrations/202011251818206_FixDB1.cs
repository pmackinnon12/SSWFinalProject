namespace SSWProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FixDB1 : DbMigration
    {
        public override void Up()
        {
            //DropForeignKey("dbo.Files", "Agent_AgentID", "dbo.Agents");
            //DropForeignKey("dbo.Files", "Customer_CustomerID", "dbo.Customers");
            //DropForeignKey("dbo.Files", "Listing_ListingID", "dbo.Listings");
            //DropIndex("dbo.Files", new[] { "Agent_AgentID" });
            //DropIndex("dbo.Files", new[] { "Customer_CustomerID" });
            //DropIndex("dbo.Files", new[] { "Listing_ListingID" });
            //RenameColumn(table: "dbo.Files", name: "Agent_AgentID", newName: "AgentID");
            //RenameColumn(table: "dbo.Files", name: "Customer_CustomerID", newName: "CustomerID");
            //RenameColumn(table: "dbo.Files", name: "Listing_ListingID", newName: "ListingID");
            AlterColumn("dbo.Files", "AgentID", c => c.Int(nullable: false));
            AlterColumn("dbo.Files", "CustomerID", c => c.Int(nullable: false));
            //AlterColumn("dbo.Files", "ListingID", c => c.Int(nullable: false));
            //CreateIndex("dbo.Files", "AgentID");
           // CreateIndex("dbo.Files", "CustomerID");
            //CreateIndex("dbo.Files", "ListingID");
            //AddForeignKey("dbo.Files", "AgentID", "dbo.Agents", "AgentID", cascadeDelete: true);
            //AddForeignKey("dbo.Files", "CustomerID", "dbo.Customers", "CustomerID", cascadeDelete: true);
            //AddForeignKey("dbo.Files", "ListingID", "dbo.Listings", "ListingID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Files", "ListingID", "dbo.Listings");
            DropForeignKey("dbo.Files", "CustomerID", "dbo.Customers");
            DropForeignKey("dbo.Files", "AgentID", "dbo.Agents");
            DropIndex("dbo.Files", new[] { "ListingID" });
            DropIndex("dbo.Files", new[] { "CustomerID" });
            DropIndex("dbo.Files", new[] { "AgentID" });
            AlterColumn("dbo.Files", "ListingID", c => c.Int());
            AlterColumn("dbo.Files", "CustomerID", c => c.Int());
            AlterColumn("dbo.Files", "AgentID", c => c.Int());
            RenameColumn(table: "dbo.Files", name: "ListingID", newName: "Listing_ListingID");
            RenameColumn(table: "dbo.Files", name: "CustomerID", newName: "Customer_CustomerID");
            RenameColumn(table: "dbo.Files", name: "AgentID", newName: "Agent_AgentID");
            CreateIndex("dbo.Files", "Listing_ListingID");
            CreateIndex("dbo.Files", "Customer_CustomerID");
            CreateIndex("dbo.Files", "Agent_AgentID");
            AddForeignKey("dbo.Files", "Listing_ListingID", "dbo.Listings", "ListingID");
            AddForeignKey("dbo.Files", "Customer_CustomerID", "dbo.Customers", "CustomerID");
            AddForeignKey("dbo.Files", "Agent_AgentID", "dbo.Agents", "AgentID");
        }
    }
}
