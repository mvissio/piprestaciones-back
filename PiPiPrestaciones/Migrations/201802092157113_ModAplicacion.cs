namespace PiPiPrestaciones.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModAplicacion : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Aplicacion", "Status", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Aplicacion", "Status");
        }
    }
}
