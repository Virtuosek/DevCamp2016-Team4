namespace BeeBack.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update4 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.UserActivity",
                c => new
                    {
                        ID = c.Guid(nullable: false),
                        UserID = c.Guid(nullable: false),
                        ActivityID = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Activity", t => t.ActivityID, cascadeDelete: true)
                .ForeignKey("dbo.User", t => t.UserID, cascadeDelete: true)
                .Index(t => t.UserID)
                .Index(t => t.ActivityID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserActivity", "UserID", "dbo.User");
            DropForeignKey("dbo.UserActivity", "ActivityID", "dbo.Activity");
            DropIndex("dbo.UserActivity", new[] { "ActivityID" });
            DropIndex("dbo.UserActivity", new[] { "UserID" });
            DropTable("dbo.UserActivity");
        }
    }
}
