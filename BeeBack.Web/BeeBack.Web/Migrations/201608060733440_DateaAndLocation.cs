namespace BeeBack.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DateaAndLocation : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Activities", "Date", c => c.DateTime(nullable: false));
            AddColumn("dbo.Activities", "Location_City", c => c.String());
            AddColumn("dbo.Activities", "Location_Street", c => c.String());
            AddColumn("dbo.Activities", "Location_ZipCode", c => c.String());
            AddColumn("dbo.Activities", "Location_Latitude", c => c.Single(nullable: false));
            AddColumn("dbo.Activities", "Location_Longitude", c => c.Single(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Activities", "Location_Longitude");
            DropColumn("dbo.Activities", "Location_Latitude");
            DropColumn("dbo.Activities", "Location_ZipCode");
            DropColumn("dbo.Activities", "Location_Street");
            DropColumn("dbo.Activities", "Location_City");
            DropColumn("dbo.Activities", "Date");
        }
    }
}
