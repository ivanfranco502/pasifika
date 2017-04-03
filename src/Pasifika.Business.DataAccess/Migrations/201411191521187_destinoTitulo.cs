namespace Pasifika.Business.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class destinoTitulo : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.DestinoTitulo",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Titulo = c.String(),
                        Texto = c.String(),
                        Orden = c.Int(nullable: false),
                        DestinoId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Destino", t => t.DestinoId)
                .Index(t => t.DestinoId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.DestinoTitulo", "DestinoId", "dbo.Destino");
            DropIndex("dbo.DestinoTitulo", new[] { "DestinoId" });
            DropTable("dbo.DestinoTitulo");
        }
    }
}
