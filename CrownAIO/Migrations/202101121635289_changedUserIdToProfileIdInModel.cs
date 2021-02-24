namespace CrownAIO.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changedUserIdToProfileIdInModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.BillingAddresses", "ProfileId", c => c.Int(nullable: false));
            AddColumn("dbo.CardInformations", "ProfileId", c => c.Int(nullable: false));
            AddColumn("dbo.ShippingAddresses", "ProfileId", c => c.Int(nullable: false));
            DropColumn("dbo.BillingAddresses", "UserId");
            DropColumn("dbo.CardInformations", "UserId");
            DropColumn("dbo.ShippingAddresses", "UserId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ShippingAddresses", "UserId", c => c.Int(nullable: false));
            AddColumn("dbo.CardInformations", "UserId", c => c.Int(nullable: false));
            AddColumn("dbo.BillingAddresses", "UserId", c => c.Int(nullable: false));
            DropColumn("dbo.ShippingAddresses", "ProfileId");
            DropColumn("dbo.CardInformations", "ProfileId");
            DropColumn("dbo.BillingAddresses", "ProfileId");
        }
    }
}
