namespace CrownAIO.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedSettingsAndItsChildEntitiesIntoModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AYCD_Solution",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SettingId = c.Int(nullable: false),
                        AccessToken = c.String(),
                        APIKey = c.String(),
                        V3Capcha = c.String(),
                        V2Capcha = c.String(),
                        GeoTestCapcha = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.DiscordSettings",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SettingId = c.Int(nullable: false),
                        WebHook = c.String(),
                        SuccessNotificationsOnly = c.Boolean(nullable: false),
                        SendOnFailure = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Settings",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ProfileId = c.Int(nullable: false),
                        DiscordSettingId = c.Int(nullable: false),
                        AYCDSolutionId = c.Int(nullable: false),
                        ActivationKey = c.String(),
                        PlaySoundOnSuccess = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Settings");
            DropTable("dbo.DiscordSettings");
            DropTable("dbo.AYCD_Solution");
        }
    }
}
