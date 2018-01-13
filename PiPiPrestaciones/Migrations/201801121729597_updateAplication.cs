namespace PiPiPrestaciones.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updateAplication : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Aplicacion", "NombreAplicacion", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Aplicacion", "NombreAplicacion");
        }
    }
}
