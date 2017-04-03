namespace Pasifika.Business.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Ciudad",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nombre = c.String(),
                        DestinoId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Destino", t => t.DestinoId)
                .Index(t => t.DestinoId);
            
            CreateTable(
                "dbo.Destino",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nombre = c.String(),
                        RegionId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Region", t => t.RegionId)
                .Index(t => t.RegionId);
            
            CreateTable(
                "dbo.Region",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nombre = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Viaje",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nombre = c.String(),
                        Comentarios = c.String(),
                        Duracion = c.Int(),
                        Paises = c.String(),
                        Ciudades = c.String(),
                        Itinerario = c.String(),
                        Alojamiento = c.String(),
                        Actividades = c.String(),
                        Translados = c.String(),
                        CuandoIr = c.String(),
                        Presupuesto = c.String(),
                        NombreCrucero = c.String(),
                        nombreTren = c.String(),
                        algo = c.String(),
                        Horarios = c.String(),
                        Categoria = c.Int(),
                        ViajeTipo = c.Int(),
                        ViajeTipo1 = c.Int(),
                        ViajeTipo2 = c.Int(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Destino", "RegionId", "dbo.Region");
            DropForeignKey("dbo.Ciudad", "DestinoId", "dbo.Destino");
            DropIndex("dbo.Destino", new[] { "RegionId" });
            DropIndex("dbo.Ciudad", new[] { "DestinoId" });
            DropTable("dbo.Viaje");
            DropTable("dbo.Region");
            DropTable("dbo.Destino");
            DropTable("dbo.Ciudad");
        }
    }
}
