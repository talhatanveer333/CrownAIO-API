namespace CrownAIO.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedProxyIntoModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Proxies",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ProfileId = c.Int(nullable: false),
                        Server = c.String(),
                        Port = c.String(),
                        LoginId = c.String(),
                        Password = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Proxies");
        }
    }
}
