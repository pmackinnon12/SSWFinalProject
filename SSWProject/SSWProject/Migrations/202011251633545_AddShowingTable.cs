namespace SSWProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddShowingTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Showings",
                c => new
                    {
                        ShowingID = c.Int(nullable: false, identity: true),
                        LisitngID = c.Int(nullable: false),
                        ShowingDate = c.DateTime(nullable: false),
                        StartTime = c.DateTime(nullable: false),
                        EndTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ShowingID);
            
            AddColumn("dbo.Agents", "Password", c => c.String(nullable: false));
            AddColumn("dbo.Agents", "JobRole", c => c.String(nullable: false, maxLength: 25));
            AlterColumn("dbo.Listings", "StreetAddress", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Listings", "Municipality", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Listings", "PostalCode", c => c.String(nullable: false, maxLength: 6));
            AlterColumn("dbo.Listings", "ProvinceOrState", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Listings", "AreaOfCity", c => c.String(nullable: false));
            AlterColumn("dbo.Listings", "Summary", c => c.String(nullable: false));
            AlterColumn("dbo.Listings", "TypeOfHeating", c => c.String(nullable: false));
            AlterColumn("dbo.Listings", "SpecialFeatures", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Listings", "SpecialFeatures", c => c.String());
            AlterColumn("dbo.Listings", "TypeOfHeating", c => c.String());
            AlterColumn("dbo.Listings", "Summary", c => c.String());
            AlterColumn("dbo.Listings", "AreaOfCity", c => c.String());
            AlterColumn("dbo.Listings", "ProvinceOrState", c => c.String());
            AlterColumn("dbo.Listings", "PostalCode", c => c.String());
            AlterColumn("dbo.Listings", "Municipality", c => c.String());
            AlterColumn("dbo.Listings", "StreetAddress", c => c.String());
            DropColumn("dbo.Agents", "JobRole");
            DropColumn("dbo.Agents", "Password");
            DropTable("dbo.Showings");
        }
    }
}
