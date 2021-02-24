namespace CrownAIO.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changedAYCD_SolutionToAYCDSolution : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.AYCD_Solution", newName: "AYCDSolutions");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.AYCDSolutions", newName: "AYCD_Solution");
        }
    }
}
