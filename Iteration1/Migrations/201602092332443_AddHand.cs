namespace Iteration1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddHand : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Hand",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        GameID = c.Int(nullable: false),
                        PlayerID = c.Int(nullable: false),
                        FirstCard = c.Int(nullable: false),
                        SecondCard = c.Int(nullable: false),
                        ThirdCard = c.Int(nullable: false),
                        FourthCard = c.Int(nullable: false),
                        TrickScore = c.Int(nullable: false),
                        WinningPlayer = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Hand");
        }
    }
}
