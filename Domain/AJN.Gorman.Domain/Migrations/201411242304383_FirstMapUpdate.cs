namespace AJN.Gorman.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FirstMapUpdate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Maps", "Name", c => c.String());
            AddColumn("dbo.Maps", "TileUrl", c => c.String());
            AddColumn("dbo.Maps", "Privacy", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Maps", "Privacy");
            DropColumn("dbo.Maps", "TileUrl");
            DropColumn("dbo.Maps", "Name");
        }
    }
}
