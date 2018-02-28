namespace PiPiPrestaciones.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addCssDescDisertante : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.DescripcionDisertante", "CssDisertanteId", c => c.Int());
            CreateIndex("dbo.DescripcionDisertante", "CssDisertanteId");
            AddForeignKey("dbo.DescripcionDisertante", "CssDisertanteId", "dbo.CssModel", "CssModelId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.DescripcionDisertante", "CssDisertanteId", "dbo.CssModel");
            DropIndex("dbo.DescripcionDisertante", new[] { "CssDisertanteId" });
            DropColumn("dbo.DescripcionDisertante", "CssDisertanteId");
        }
    }
}
