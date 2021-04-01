namespace TixFix.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class second : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Opponent",
                c => new
                    {
                        OpponentId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.OpponentId);
            
            CreateIndex("dbo.Ticket", "OpponentId");
            AddForeignKey("dbo.Ticket", "OpponentId", "dbo.Opponent", "OpponentId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Ticket", "OpponentId", "dbo.Opponent");
            DropIndex("dbo.Ticket", new[] { "OpponentId" });
            DropTable("dbo.Opponent");
        }
    }
}
