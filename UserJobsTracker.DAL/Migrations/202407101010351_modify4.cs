namespace UserJobsTracker.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class modify4 : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.Jobs");
            AddColumn("dbo.Jobs", "LeaveDate", c => c.DateTime());
            AlterColumn("dbo.Jobs", "Id", c => c.Long(nullable: false, identity: true));
            AddPrimaryKey("dbo.Jobs", "Id");
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.Jobs");
            AlterColumn("dbo.Jobs", "Id", c => c.Int(nullable: false, identity: true));
            DropColumn("dbo.Jobs", "LeaveDate");
            AddPrimaryKey("dbo.Jobs", "Id");
        }
    }
}
