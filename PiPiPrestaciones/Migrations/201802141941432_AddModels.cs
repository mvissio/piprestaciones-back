namespace PiPiPrestaciones.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddModels : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.DescripcionDisertante",
                c => new
                    {
                        DescripcionDisertanteId = c.Int(nullable: false, identity: true),
                        TextDescription = c.String(),
                        ClassDescription = c.String(),
                        TextAlingDescription = c.String(),
                        OrderDescription = c.Int(nullable: false),
                        DisertanteId = c.Int(),
                    })
                .PrimaryKey(t => t.DescripcionDisertanteId)
                .ForeignKey("dbo.Disertante", t => t.DisertanteId)
                .Index(t => t.DisertanteId);
            
            CreateTable(
                "dbo.Disertante",
                c => new
                    {
                        DisertanteId = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        FullName = c.String(),
                        ImageUrl = c.String(),
                        NationalityUrl = c.String(),
                        WebUrl = c.String(),
                        CssModelDisertanteId = c.Int(),
                        AplicacionId = c.Int(),
                    })
                .PrimaryKey(t => t.DisertanteId)
                .ForeignKey("dbo.Aplicacion", t => t.AplicacionId)
                .ForeignKey("dbo.CssModel", t => t.CssModelDisertanteId)
                .Index(t => t.CssModelDisertanteId)
                .Index(t => t.AplicacionId);
            
            CreateTable(
                "dbo.DetailsPlanimetry",
                c => new
                    {
                        DetailsPlanimetryId = c.Int(nullable: false, identity: true),
                        TitleDetails = c.String(),
                        DescriptionDetails = c.String(),
                        CssModelDetailsPlanimetryId = c.Int(),
                        PlanimetryId = c.Int(),
                    })
                .PrimaryKey(t => t.DetailsPlanimetryId)
                .ForeignKey("dbo.CssModel", t => t.CssModelDetailsPlanimetryId)
                .ForeignKey("dbo.Planimetry", t => t.PlanimetryId)
                .Index(t => t.CssModelDetailsPlanimetryId)
                .Index(t => t.PlanimetryId);
            
            CreateTable(
                "dbo.Planimetry",
                c => new
                    {
                        PlanimetryId = c.Int(nullable: false, identity: true),
                        TitlePlanimetry = c.String(),
                        FooterPlanimetry = c.String(),
                        UrlImagePlanimetry = c.String(),
                        CssModelPlanimetryId = c.Int(),
                        AplicacionId = c.Int(),
                    })
                .PrimaryKey(t => t.PlanimetryId)
                .ForeignKey("dbo.Aplicacion", t => t.AplicacionId)
                .ForeignKey("dbo.CssModel", t => t.CssModelPlanimetryId)
                .Index(t => t.CssModelPlanimetryId)
                .Index(t => t.AplicacionId);
            
            DropColumn("dbo.Map", "IsMap");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Map", "IsMap", c => c.Boolean());
            DropForeignKey("dbo.DetailsPlanimetry", "PlanimetryId", "dbo.Planimetry");
            DropForeignKey("dbo.Planimetry", "CssModelPlanimetryId", "dbo.CssModel");
            DropForeignKey("dbo.Planimetry", "AplicacionId", "dbo.Aplicacion");
            DropForeignKey("dbo.DetailsPlanimetry", "CssModelDetailsPlanimetryId", "dbo.CssModel");
            DropForeignKey("dbo.DescripcionDisertante", "DisertanteId", "dbo.Disertante");
            DropForeignKey("dbo.Disertante", "CssModelDisertanteId", "dbo.CssModel");
            DropForeignKey("dbo.Disertante", "AplicacionId", "dbo.Aplicacion");
            DropIndex("dbo.Planimetry", new[] { "AplicacionId" });
            DropIndex("dbo.Planimetry", new[] { "CssModelPlanimetryId" });
            DropIndex("dbo.DetailsPlanimetry", new[] { "PlanimetryId" });
            DropIndex("dbo.DetailsPlanimetry", new[] { "CssModelDetailsPlanimetryId" });
            DropIndex("dbo.Disertante", new[] { "AplicacionId" });
            DropIndex("dbo.Disertante", new[] { "CssModelDisertanteId" });
            DropIndex("dbo.DescripcionDisertante", new[] { "DisertanteId" });
            DropTable("dbo.Planimetry");
            DropTable("dbo.DetailsPlanimetry");
            DropTable("dbo.Disertante");
            DropTable("dbo.DescripcionDisertante");
        }
    }
}
