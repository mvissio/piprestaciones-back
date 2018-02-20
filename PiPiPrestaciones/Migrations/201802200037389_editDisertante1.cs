namespace PiPiPrestaciones.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class editDisertante1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Disertante", "FullName", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Disertante", "FullName", c => c.String());
        }
    }
}
