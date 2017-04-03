namespace Pasifika.Business.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class arregloViajes1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Viaje", "DestinoId", c => c.Int());
            AddColumn("dbo.Viaje", "CiudadId", c => c.Int());
            CreateIndex("dbo.Viaje", "DestinoId");
            CreateIndex("dbo.Viaje", "CiudadId");
            AddForeignKey("dbo.Viaje", "DestinoId", "dbo.Destino", "Id");
            AddForeignKey("dbo.Viaje", "CiudadId", "dbo.Ciudad", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Viaje", "CiudadId", "dbo.Ciudad");
            DropForeignKey("dbo.Viaje", "DestinoId", "dbo.Destino");
            DropIndex("dbo.Viaje", new[] { "CiudadId" });
            DropIndex("dbo.Viaje", new[] { "DestinoId" });
            DropColumn("dbo.Viaje", "CiudadId");
            DropColumn("dbo.Viaje", "DestinoId");
        }
    }
}
