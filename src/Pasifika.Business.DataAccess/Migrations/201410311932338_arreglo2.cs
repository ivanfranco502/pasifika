namespace Pasifika.Business.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class arreglo2 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Foto",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Archivo = c.String(),
                        ViajeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Viaje", t => t.ViajeId)
                .Index(t => t.ViajeId);
            
            AddColumn("dbo.Viaje", "ImagenListado", c => c.String());
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Foto", "ViajeId", "dbo.Viaje");
            DropIndex("dbo.Foto", new[] { "ViajeId" });
            DropColumn("dbo.Viaje", "ImagenListado");
            DropTable("dbo.Foto");
        }
    }
}
