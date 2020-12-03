namespace SSWProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddListingPrice : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Listings", "SalesPrice", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Listings", "SalesPrice");
        }
    }
}
