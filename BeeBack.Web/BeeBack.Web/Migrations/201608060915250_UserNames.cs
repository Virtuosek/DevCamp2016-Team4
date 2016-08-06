namespace BeeBack.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UserNames : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ApplicationUsers", "Firstname", c => c.String());
            AddColumn("dbo.ApplicationUsers", "Lastname", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.ApplicationUsers", "Lastname");
            DropColumn("dbo.ApplicationUsers", "Firstname");
        }
    }
}
