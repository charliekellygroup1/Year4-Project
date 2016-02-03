namespace Iteration1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddGame : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Game",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        IsFirstHalf = c.Boolean(nullable: false),
                        Score = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Game");
        }
    }
}
