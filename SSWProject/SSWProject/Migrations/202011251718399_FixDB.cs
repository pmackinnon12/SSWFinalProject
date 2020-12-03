namespace SSWProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FixDB : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Agents", "FileID", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Agents", "FileID");
        }
    }
}
