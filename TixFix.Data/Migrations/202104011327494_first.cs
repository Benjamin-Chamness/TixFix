namespace TixFix.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class first : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Ticket", "SeatId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Ticket", "SeatId");
        }
    }
}
