namespace PiPiPrestaciones.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Dominio : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Aplicacion",
                c => new
                    {
                        AplicacionId = c.Int(nullable: false, identity: true),
                        Titulo = c.String(),
                        AppIndependiente = c.Boolean(nullable: false),
                        Idioma = c.String(),
                        LenguajePorDefecto = c.Boolean(nullable: false),
                        ClaveApp = c.String(),
                        AdminUser = c.String(),
                        AdminPasword = c.String(),
                        ApiKey = c.String(),
                        Canal = c.String(),
                        UrlImagenN = c.String(),
                        UrlImagen2 = c.String(),
                        UrlImagen1 = c.String(),
                        HashTagTwiter = c.String(),
                        CssAplicacionId = c.Int(),
                        VersionId = c.String(),
                        LastModification = c.DateTime(),
                        CreateAt = c.DateTime(nullable: false),
                        CreateBy = c.String(),
                    })
                .PrimaryKey(t => t.AplicacionId)
                .ForeignKey("dbo.CssModel", t => t.CssAplicacionId)
                .Index(t => t.CssAplicacionId);
            
            CreateTable(
                "dbo.CssModel",
                c => new
                    {
                        CssModelId = c.Int(nullable: false, identity: true),
                        FontFamily = c.String(),
                        ColorText = c.String(),
                        ColorBack = c.String(),
                        BorderSize = c.Int(),
                        ImageBack = c.String(),
                        ColorIcon = c.String(),
                    })
                .PrimaryKey(t => t.CssModelId);
            
            CreateTable(
                "dbo.Menu",
                c => new
                    {
                        MenuId = c.Int(nullable: false, identity: true),
                        TitleMenu = c.String(),
                        Status = c.Boolean(nullable: false),
                        Type = c.String(),
                        Order = c.Int(),
                        Icon = c.String(),
                        CssModelMenuId = c.Int(),
                        CssModelItemMenuId = c.Int(),
                        AplicacionId = c.Int(),
                    })
                .PrimaryKey(t => t.MenuId)
                .ForeignKey("dbo.Aplicacion", t => t.AplicacionId)
                .ForeignKey("dbo.CssModel", t => t.CssModelItemMenuId)
                .ForeignKey("dbo.CssModel", t => t.CssModelMenuId)
                .Index(t => t.CssModelMenuId)
                .Index(t => t.CssModelItemMenuId)
                .Index(t => t.AplicacionId);
            
            CreateTable(
                "dbo.Map",
                c => new
                    {
                        MapId = c.String(nullable: false, maxLength: 128),
                        Order = c.Int(),
                        Title = c.String(),
                        Lat = c.Decimal(precision: 18, scale: 2),
                        Lng = c.Decimal(precision: 18, scale: 2),
                        Zoom = c.Int(),
                        IsMap = c.Boolean(),
                        BorderColor = c.String(),
                        BorderSize = c.Int(),
                    })
                .PrimaryKey(t => t.MapId);
            
            CreateTable(
                "dbo.StaticContent",
                c => new
                    {
                        StaticContentId = c.Int(nullable: false, identity: true),
                        StaticContentType = c.String(),
                        StaticContentOrder = c.Int(),
                        StaticContentText = c.String(),
                        cssStaticContentId = c.Int(),
                        StaticPage_StaticPageId = c.Int(),
                    })
                .PrimaryKey(t => t.StaticContentId)
                .ForeignKey("dbo.CssModel", t => t.cssStaticContentId)
                .ForeignKey("dbo.StaticPage", t => t.StaticPage_StaticPageId)
                .Index(t => t.cssStaticContentId)
                .Index(t => t.StaticPage_StaticPageId);
            
            CreateTable(
                "dbo.StaticPage",
                c => new
                    {
                        StaticPageId = c.Int(nullable: false, identity: true),
                        PageTitle = c.String(),
                        CssStaticPage_CssModelId = c.Int(),
                    })
                .PrimaryKey(t => t.StaticPageId)
                .ForeignKey("dbo.CssModel", t => t.CssStaticPage_CssModelId)
                .Index(t => t.CssStaticPage_CssModelId);
            
            CreateTable(
                "dbo.Type",
                c => new
                    {
                        TypeId = c.Int(nullable: false, identity: true),
                        TypeName = c.String(),
                        Status = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.TypeId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.StaticContent", "StaticPage_StaticPageId", "dbo.StaticPage");
            DropForeignKey("dbo.StaticPage", "CssStaticPage_CssModelId", "dbo.CssModel");
            DropForeignKey("dbo.StaticContent", "cssStaticContentId", "dbo.CssModel");
            DropForeignKey("dbo.Menu", "CssModelMenuId", "dbo.CssModel");
            DropForeignKey("dbo.Menu", "CssModelItemMenuId", "dbo.CssModel");
            DropForeignKey("dbo.Menu", "AplicacionId", "dbo.Aplicacion");
            DropForeignKey("dbo.Aplicacion", "CssAplicacionId", "dbo.CssModel");
            DropIndex("dbo.StaticPage", new[] { "CssStaticPage_CssModelId" });
            DropIndex("dbo.StaticContent", new[] { "StaticPage_StaticPageId" });
            DropIndex("dbo.StaticContent", new[] { "cssStaticContentId" });
            DropIndex("dbo.Menu", new[] { "AplicacionId" });
            DropIndex("dbo.Menu", new[] { "CssModelItemMenuId" });
            DropIndex("dbo.Menu", new[] { "CssModelMenuId" });
            DropIndex("dbo.Aplicacion", new[] { "CssAplicacionId" });
            DropTable("dbo.Type");
            DropTable("dbo.StaticPage");
            DropTable("dbo.StaticContent");
            DropTable("dbo.Map");
            DropTable("dbo.Menu");
            DropTable("dbo.CssModel");
            DropTable("dbo.Aplicacion");
        }
    }
}
