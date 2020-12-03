namespace SSWProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddFileTables3 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Files", "Agent_AgentID", "dbo.Agents");
            DropForeignKey("dbo.Files", "Customer_CustomerID", "dbo.Customers");
            DropIndex("dbo.Files", new[] { "Agent_AgentID" });
            DropIndex("dbo.Files", new[] { "Customer_CustomerID" });
            RenameColumn(table: "dbo.Files", name: "Agent_AgentID", newName: "AgentID");
            RenameColumn(table: "dbo.Files", name: "Customer_CustomerID", newName: "CustomerID");
            AlterColumn("dbo.Files", "AgentID", c => c.Int(nullable: false));
            AlterColumn("dbo.Files", "CustomerID", c => c.Int(nullable: false));
            CreateIndex("dbo.Files", "CustomerID");
            CreateIndex("dbo.Files", "AgentID");
            AddForeignKey("dbo.Files", "AgentID", "dbo.Agents", "AgentID", cascadeDelete: true);
            AddForeignKey("dbo.Files", "CustomerID", "dbo.Customers", "CustomerID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Files", "CustomerID", "dbo.Customers");
            DropForeignKey("dbo.Files", "AgentID", "dbo.Agents");
            DropIndex("dbo.Files", new[] { "AgentID" });
            DropIndex("dbo.Files", new[] { "CustomerID" });
            AlterColumn("dbo.Files", "CustomerID", c => c.Int());
            AlterColumn("dbo.Files", "AgentID", c => c.Int());
            RenameColumn(table: "dbo.Files", name: "CustomerID", newName: "Customer_CustomerID");
            RenameColumn(table: "dbo.Files", name: "AgentID", newName: "Agent_AgentID");
            CreateIndex("dbo.Files", "Customer_CustomerID");
            CreateIndex("dbo.Files", "Agent_AgentID");
            AddForeignKey("dbo.Files", "Customer_CustomerID", "dbo.Customers", "CustomerID");
            AddForeignKey("dbo.Files", "Agent_AgentID", "dbo.Agents", "AgentID");
        }
    }
}
