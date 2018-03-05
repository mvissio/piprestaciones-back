namespace PiPiPrestaciones.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Status_Planimetry : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Planimetry", "Status", c => c.Boolean(nullable: false));
            AddColumn("dbo.Map", "Status", c => c.Boolean(nullable: false));
            AddColumn("dbo.StaticPage", "Status", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.StaticPage", "Status");
            DropColumn("dbo.Map", "Status");
            DropColumn("dbo.Planimetry", "Status");
        }
    }
}
