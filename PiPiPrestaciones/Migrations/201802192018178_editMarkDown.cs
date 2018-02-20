namespace PiPiPrestaciones.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class editMarkDown : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.MarkDownModel", "PreviewValue", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.MarkDownModel", "PreviewValue");
        }
    }
}
