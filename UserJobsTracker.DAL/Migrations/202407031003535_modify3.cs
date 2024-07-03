namespace UserJobsTracker.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class modify3 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.SystemUsers", "DefaultBranchId", "dbo.Branches");
            DropIndex("dbo.SystemUsers", new[] { "DefaultBranchId" });
            AlterColumn("dbo.SystemUsers", "DefaultBranchId", c => c.Int());
            CreateIndex("dbo.SystemUsers", "DefaultBranchId");
            AddForeignKey("dbo.SystemUsers", "DefaultBranchId", "dbo.Branches", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SystemUsers", "DefaultBranchId", "dbo.Branches");
            DropIndex("dbo.SystemUsers", new[] { "DefaultBranchId" });
            AlterColumn("dbo.SystemUsers", "DefaultBranchId", c => c.Int(nullable: false));
            CreateIndex("dbo.SystemUsers", "DefaultBranchId");
            AddForeignKey("dbo.SystemUsers", "DefaultBranchId", "dbo.Branches", "Id", cascadeDelete: true);
        }
    }
}
