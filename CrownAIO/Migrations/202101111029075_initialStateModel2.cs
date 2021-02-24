namespace CrownAIO.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initialStateModel2 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CardInfromations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        CardNumber = c.Double(nullable: false),
                        Expiration = c.DateTime(nullable: false),
                        CVV = c.Int(nullable: false),
                        CardHolderName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ShippingAddresses",
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
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CardInformationId = c.Int(nullable: false),
                        ShippingAddressId = c.Int(nullable: false),
                        Name = c.String(),
                        ProfilePicUrl = c.String(),
                        TotalRevenue = c.Double(nullable: false),
                        TotalDeclines = c.Int(nullable: false),
                        Changes = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Users");
            DropTable("dbo.ShippingAddresses");
            DropTable("dbo.CardInfromations");
        }
    }
}
