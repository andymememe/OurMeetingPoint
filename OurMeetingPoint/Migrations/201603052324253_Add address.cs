namespace OurMeetingPoint.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Addaddress : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.MeetingPoints", "Address", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.MeetingPoints", "Address");
        }
    }
}
