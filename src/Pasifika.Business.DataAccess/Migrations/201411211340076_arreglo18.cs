namespace Pasifika.Business.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class arreglo18 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Destino", "Resumen", c => c.String());
            AddColumn("dbo.Prensa", "Revista", c => c.String());
            AddColumn("dbo.Prensa", "Fecha", c => c.DateTime(nullable: false));
            AddColumn("dbo.Prensa", "Resumen", c => c.String());
            AddColumn("dbo.Prensa", "Link", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Prensa", "Link");
            DropColumn("dbo.Prensa", "Resumen");
            DropColumn("dbo.Prensa", "Fecha");
            DropColumn("dbo.Prensa", "Revista");
            DropColumn("dbo.Destino", "Resumen");
        }
    }
}
