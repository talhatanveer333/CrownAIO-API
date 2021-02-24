namespace CrownAIO.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class removedSameAsBillingFromBillingAddress : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.BillingAddresses", "BillingSameAsShipping");
        }
        
        public override void Down()
        {
            AddColumn("dbo.BillingAddresses", "BillingSameAsShipping", c => c.Boolean(nullable: false));
        }
    }
}
