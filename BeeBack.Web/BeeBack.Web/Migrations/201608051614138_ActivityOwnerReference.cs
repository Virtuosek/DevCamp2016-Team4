namespace BeeBack.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ActivityOwnerReference : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.UserActivities", "ActivityID", "dbo.Activities");
            DropForeignKey("dbo.UserActivities", "UserID", "dbo.ApplicationUsers");
            DropIndex("dbo.Activities", new[] { "ApplicationUser_Id" });
            RenameColumn(table: "dbo.Activities", name: "ApplicationUser_Id", newName: "UserId");
            AlterColumn("dbo.Activities", "UserId", c => c.String(nullable: false, maxLength: 128));
            CreateIndex("dbo.Activities", "UserId");
            AddForeignKey("dbo.UserActivities", "ActivityID", "dbo.Activities", "ID");
            AddForeignKey("dbo.UserActivities", "UserID", "dbo.ApplicationUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserActivities", "UserID", "dbo.ApplicationUsers");
            DropForeignKey("dbo.UserActivities", "ActivityID", "dbo.Activities");
            DropIndex("dbo.Activities", new[] { "UserId" });
            AlterColumn("dbo.Activities", "UserId", c => c.String(maxLength: 128));
            RenameColumn(table: "dbo.Activities", name: "UserId", newName: "ApplicationUser_Id");
            CreateIndex("dbo.Activities", "ApplicationUser_Id");
            AddForeignKey("dbo.UserActivities", "UserID", "dbo.ApplicationUsers", "Id", cascadeDelete: true);
            AddForeignKey("dbo.UserActivities", "ActivityID", "dbo.Activities", "ID", cascadeDelete: true);
        }
    }
}
