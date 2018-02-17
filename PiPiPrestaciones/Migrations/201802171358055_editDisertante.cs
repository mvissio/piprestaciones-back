namespace PiPiPrestaciones.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class editDisertante : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.MarkDownModel",
                c => new
                    {
                        MarkDownModelId = c.Int(nullable: false, identity: true),
                        HtmlValue = c.String(),
                        MarkDownValue = c.String(),
                    })
                .PrimaryKey(t => t.MarkDownModelId);
            
            AddColumn("dbo.DescripcionDisertante", "MarkDownDisertanteId", c => c.Int());
            AddColumn("dbo.Disertante", "Status", c => c.Boolean(nullable: false));
            CreateIndex("dbo.DescripcionDisertante", "MarkDownDisertanteId");
            AddForeignKey("dbo.DescripcionDisertante", "MarkDownDisertanteId", "dbo.MarkDownModel", "MarkDownModelId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.DescripcionDisertante", "MarkDownDisertanteId", "dbo.MarkDownModel");
            DropIndex("dbo.DescripcionDisertante", new[] { "MarkDownDisertanteId" });
            DropColumn("dbo.Disertante", "Status");
            DropColumn("dbo.DescripcionDisertante", "MarkDownDisertanteId");
            DropTable("dbo.MarkDownModel");
        }
    }
}
