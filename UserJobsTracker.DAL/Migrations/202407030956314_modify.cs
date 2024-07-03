namespace UserJobsTracker.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class modify : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.SystemUsers", newName: "AspNetUsers");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.AspNetUsers", newName: "SystemUsers");
        }
    }
}
