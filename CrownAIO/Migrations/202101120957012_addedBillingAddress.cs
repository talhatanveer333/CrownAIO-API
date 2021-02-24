namespace CrownAIO.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedBillingAddress : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BillingAddresses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        ProfileName = c.String(),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Email = c.String(),
                        PhoneNumber = c.String(),
                        Address1 = c.String(),
                        Address2 = c.String(),
                        Country = c.String(),
                        State = c.String(),
                        City = c.String(),
                        ZipCode = c.String(),
                        BillingSameAsShipping = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.BillingAddresses");
        }
    }
}
