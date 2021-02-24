namespace CrownAIO.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedRecentUserActivitiesIntoModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.UserActivities",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IPAddress = c.String(),
                        Location = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.UserActivities");
        }
    }
}
