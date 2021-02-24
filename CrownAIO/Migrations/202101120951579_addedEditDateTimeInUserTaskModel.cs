namespace CrownAIO.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedEditDateTimeInUserTaskModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.UserTasks", "EditDateTime", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.UserTasks", "EditDateTime");
        }
    }
}
