namespace CrownAIO.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedProfileIdInUserTaskModel : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.CardInfromations", newName: "CardInformations");
            AddColumn("dbo.UserTasks", "ProfileId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.UserTasks", "ProfileId");
            RenameTable(name: "dbo.CardInformations", newName: "CardInfromations");
        }
    }
}
