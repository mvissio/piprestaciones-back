namespace PiPiPrestaciones.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddModels : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.DescipcionDisertante",
                c => new
                    {
                        IdDescription = c.Int(nullable: false, identity: true),
                        TextDescription = c.String(),
                        ClassDescription = c.String(),
                        TextAlingDescription = c.String(),
                        OrderDescription = c.Int(nullable: false),
                        DisertanteId = c.Int(),
                    })
                .PrimaryKey(t => t.IdDescription)
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
                "dbo.DetaisPlanimetry",
                c => new
                    {
                        IdDetails = c.Int(nullable: false, identity: true),
                        TitleDetails = c.String(),
                        DescriptionDetails = c.String(),
                        CssModelDetailsPlanimetryId = c.Int(),
                        PlanimetryId = c.Int(),
                    })
                .PrimaryKey(t => t.IdDetails)
                .ForeignKey("dbo.CssModel", t => t.CssModelDetailsPlanimetryId)
                .ForeignKey("dbo.Planimetry", t => t.PlanimetryId)
                .Index(t => t.CssModelDetailsPlanimetryId)
                .Index(t => t.PlanimetryId);
            
            CreateTable(
                "dbo.Planimetry",
                c => new
                    {
                        IdPlanimery = c.Int(nullable: false, identity: true),
                        TitlePlanimetry = c.String(),
                        FooterPlanimetry = c.String(),
                        UrlImagePlanimetry = c.String(),
                        CssModelPlanimetryId = c.Int(),
                        AplicacionId = c.Int(),
                    })
                .PrimaryKey(t => t.IdPlanimery)
                .ForeignKey("dbo.Aplicacion", t => t.AplicacionId)
                .ForeignKey("dbo.CssModel", t => t.CssModelPlanimetryId)
                .Index(t => t.CssModelPlanimetryId)
                .Index(t => t.AplicacionId);
            
            DropColumn("dbo.Map", "IsMap");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Map", "IsMap", c => c.Boolean());
            DropForeignKey("dbo.DetaisPlanimetry", "PlanimetryId", "dbo.Planimetry");
            DropForeignKey("dbo.Planimetry", "CssModelPlanimetryId", "dbo.CssModel");
            DropForeignKey("dbo.Planimetry", "AplicacionId", "dbo.Aplicacion");
            DropForeignKey("dbo.DetaisPlanimetry", "CssModelDetailsPlanimetryId", "dbo.CssModel");
            DropForeignKey("dbo.DescipcionDisertante", "DisertanteId", "dbo.Disertante");
            DropForeignKey("dbo.Disertante", "CssModelDisertanteId", "dbo.CssModel");
            DropForeignKey("dbo.Disertante", "AplicacionId", "dbo.Aplicacion");
            DropIndex("dbo.Planimetry", new[] { "AplicacionId" });
            DropIndex("dbo.Planimetry", new[] { "CssModelPlanimetryId" });
            DropIndex("dbo.DetaisPlanimetry", new[] { "PlanimetryId" });
            DropIndex("dbo.DetaisPlanimetry", new[] { "CssModelDetailsPlanimetryId" });
            DropIndex("dbo.Disertante", new[] { "AplicacionId" });
            DropIndex("dbo.Disertante", new[] { "CssModelDisertanteId" });
            DropIndex("dbo.DescipcionDisertante", new[] { "DisertanteId" });
            DropTable("dbo.Planimetry");
            DropTable("dbo.DetaisPlanimetry");
            DropTable("dbo.Disertante");
            DropTable("dbo.DescipcionDisertante");
        }
    }
}
