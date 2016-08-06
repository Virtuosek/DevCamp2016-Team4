namespace BeeBack.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addpictureurl : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ApplicationUsers", "PictureUrl", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.ApplicationUsers", "PictureUrl");
        }
    }
}
