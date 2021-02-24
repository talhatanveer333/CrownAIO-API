namespace CrownAIO.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedUserTaskInModel : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Users", newName: "Profiles");
            CreateTable(
                "dbo.UserTasks",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Store = c.String(),
                        Product = c.String(),
                        Size = c.String(),
                        Profile = c.String(),
                        Proxy = c.String(),
                        Status = c.String(),
                        DateTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.UserTasks");
            RenameTable(name: "dbo.Profiles", newName: "Users");
        }
    }
}
