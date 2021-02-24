namespace CrownAIO.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changedUserTaskAttributes : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.UserTasks", "ProxyId", c => c.String());
            DropColumn("dbo.UserTasks", "Profile");
            DropColumn("dbo.UserTasks", "Proxy");
        }
        
        public override void Down()
        {
            AddColumn("dbo.UserTasks", "Proxy", c => c.String());
            AddColumn("dbo.UserTasks", "Profile", c => c.String());
            DropColumn("dbo.UserTasks", "ProxyId");
        }
    }
}
