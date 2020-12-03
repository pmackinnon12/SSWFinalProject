namespace SSWProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FiexedModels : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Listings", "Province", c => c.Int(nullable: false));
            AlterColumn("dbo.Agents", "Province", c => c.Int(nullable: false));
            AlterColumn("dbo.Customers", "Province", c => c.Int(nullable: false));
            AlterColumn("dbo.Listings", "TypeOfHeating", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Listings", "TypeOfHeating", c => c.String(nullable: false, maxLength: 25));
            AlterColumn("dbo.Customers", "Province", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Agents", "Province", c => c.String(nullable: false, maxLength: 50));
            DropColumn("dbo.Listings", "Province");
        }
    }
}
