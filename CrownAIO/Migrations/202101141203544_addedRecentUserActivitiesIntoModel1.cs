namespace CrownAIO.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedRecentUserActivitiesIntoModel1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.UserActivities", "profileId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.UserActivities", "profileId");
        }
    }
}
