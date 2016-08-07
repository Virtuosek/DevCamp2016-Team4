namespace BeeBack.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ActivityDriverAndShortcode : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Activities", "DriverId", c => c.String(maxLength: 128));
            AddColumn("dbo.Activities", "ShortCode", c => c.String(nullable: false));
            CreateIndex("dbo.Activities", "DriverId");
            AddForeignKey("dbo.Activities", "DriverId", "dbo.ApplicationUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Activities", "DriverId", "dbo.ApplicationUsers");
            DropIndex("dbo.Activities", new[] { "DriverId" });
            DropColumn("dbo.Activities", "ShortCode");
            DropColumn("dbo.Activities", "DriverId");
        }
    }
}
