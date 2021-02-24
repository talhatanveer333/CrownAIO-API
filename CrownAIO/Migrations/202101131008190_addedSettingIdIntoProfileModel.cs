namespace CrownAIO.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedSettingIdIntoProfileModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Profiles", "SettingId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Profiles", "SettingId");
        }
    }
}
