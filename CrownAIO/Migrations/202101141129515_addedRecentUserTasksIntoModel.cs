namespace CrownAIO.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedRecentUserTasksIntoModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.RecentUserTasks",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ProfileId = c.Int(nullable: false),
                        ProxyId = c.String(),
                        Store = c.String(),
                        Product = c.String(),
                        Size = c.String(),
                        Status = c.String(),
                        DateTime = c.DateTime(nullable: false),
                        EditDateTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.RecentUserTasks");
        }
    }
}
