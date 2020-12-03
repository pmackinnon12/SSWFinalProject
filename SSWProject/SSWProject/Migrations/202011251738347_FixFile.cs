namespace SSWProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FixFile : DbMigration
    {
        public override void Up()
        {
            DropTable("dbo.Files");
        }
        
        public override void Down()
        {
        }
    }
}
