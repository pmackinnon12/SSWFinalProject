namespace SSWProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FixTables1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Agents", "HomePhone", c => c.String(nullable: false, maxLength: 15));
            AlterColumn("dbo.Agents", "CellPhone", c => c.String(maxLength: 15));
            AlterColumn("dbo.Agents", "OfficePhone", c => c.String(nullable: false, maxLength: 15));
            AlterColumn("dbo.Customers", "HomePhone", c => c.String(nullable: false, maxLength: 15));
            AlterColumn("dbo.Customers", "CellPhone", c => c.String(maxLength: 15));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Customers", "CellPhone", c => c.String(maxLength: 10));
            AlterColumn("dbo.Customers", "HomePhone", c => c.String(nullable: false, maxLength: 10));
            AlterColumn("dbo.Agents", "OfficePhone", c => c.String(nullable: false, maxLength: 10));
            AlterColumn("dbo.Agents", "CellPhone", c => c.String(maxLength: 10));
            AlterColumn("dbo.Agents", "HomePhone", c => c.String(nullable: false, maxLength: 10));
        }
    }
}
