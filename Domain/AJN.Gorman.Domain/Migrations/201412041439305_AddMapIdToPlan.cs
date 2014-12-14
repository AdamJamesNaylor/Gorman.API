namespace AJN.Gorman.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddMapIdToPlan : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Plans", "MapId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Plans", "MapId");
        }
    }
}
