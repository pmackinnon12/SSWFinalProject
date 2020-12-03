namespace SSWProject.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddFileTables2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Files", "AgentID", "dbo.Agents");
            DropForeignKey("dbo.Files", "CustomerID", "dbo.Customers");
            DropIndex("dbo.Files", new[] { "CustomerID" });
            DropIndex("dbo.Files", new[] { "AgentID" });
            RenameColumn(table: "dbo.Files", name: "AgentID", newName: "Agent_AgentID");
            RenameColumn(table: "dbo.Files", name: "CustomerID", newName: "Customer_CustomerID");
            AlterColumn("dbo.Files", "Customer_CustomerID", c => c.Int());
            AlterColumn("dbo.Files", "Agent_AgentID", c => c.Int());
            CreateIndex("dbo.Files", "Agent_AgentID");
            CreateIndex("dbo.Files", "Customer_CustomerID");
            AddForeignKey("dbo.Files", "Agent_AgentID", "dbo.Agents", "AgentID");
            AddForeignKey("dbo.Files", "Customer_CustomerID", "dbo.Customers", "CustomerID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Files", "Customer_CustomerID", "dbo.Customers");
            DropForeignKey("dbo.Files", "Agent_AgentID", "dbo.Agents");
            DropIndex("dbo.Files", new[] { "Customer_CustomerID" });
            DropIndex("dbo.Files", new[] { "Agent_AgentID" });
            AlterColumn("dbo.Files", "Agent_AgentID", c => c.Int(nullable: false));
            AlterColumn("dbo.Files", "Customer_CustomerID", c => c.Int(nullable: false));
            RenameColumn(table: "dbo.Files", name: "Customer_CustomerID", newName: "CustomerID");
            RenameColumn(table: "dbo.Files", name: "Agent_AgentID", newName: "AgentID");
            CreateIndex("dbo.Files", "AgentID");
            CreateIndex("dbo.Files", "CustomerID");
            AddForeignKey("dbo.Files", "CustomerID", "dbo.Customers", "CustomerID", cascadeDelete: true);
            AddForeignKey("dbo.Files", "AgentID", "dbo.Agents", "AgentID", cascadeDelete: true);
        }
    }
}
