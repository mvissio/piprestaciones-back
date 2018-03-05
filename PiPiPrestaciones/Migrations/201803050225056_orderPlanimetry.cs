namespace PiPiPrestaciones.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class orderPlanimetry : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Planimetry", "OrderPlanimetry", c => c.Boolean());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Planimetry", "OrderPlanimetry", c => c.Int(nullable: false));
        }
    }
}
