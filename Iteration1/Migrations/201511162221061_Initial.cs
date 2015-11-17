namespace Iteration1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Card",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        CardSuit = c.Int(nullable: false),
                        CardValue = c.Int(nullable: false),
                        ImagePath = c.String(),
                        PlayerRef = c.Int(nullable: false),
                        CardPlayed = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Player",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        PlayerRef = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Trick",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        TrickCard = c.String(),
                        TrickIndex = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Trick");
            DropTable("dbo.Player");
            DropTable("dbo.Card");
        }
    }
}
