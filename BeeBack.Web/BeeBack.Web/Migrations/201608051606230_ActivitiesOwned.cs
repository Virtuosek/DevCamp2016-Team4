namespace BeeBack.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ActivitiesOwned : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Activities", "ApplicationUser_Id", c => c.String(maxLength: 128));
            CreateIndex("dbo.Activities", "ApplicationUser_Id");
            AddForeignKey("dbo.Activities", "ApplicationUser_Id", "dbo.ApplicationUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Activities", "ApplicationUser_Id", "dbo.ApplicationUsers");
            DropIndex("dbo.Activities", new[] { "ApplicationUser_Id" });
            DropColumn("dbo.Activities", "ApplicationUser_Id");
        }
    }
}
