namespace UserJobsTracker.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeSystemUserTableName : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.AspNetUsers", newName: "SystemUsers");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.SystemUsers", newName: "AspNetUsers");
        }
    }
}
