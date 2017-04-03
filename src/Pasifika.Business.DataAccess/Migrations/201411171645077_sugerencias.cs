namespace Pasifika.Business.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class sugerencias : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Sugerencia", "PaginaId", "dbo.Pagina");
            DropIndex("dbo.Sugerencia", new[] { "PaginaId" });
            CreateTable(
                "dbo.Destacado",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Titulo = c.String(),
                        Foto = c.String(),
                        SubTitulo = c.String(),
                        Link = c.String(),
                        Orden = c.Int(nullable: false),
                        PaginaId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Pagina", t => t.PaginaId)
                .Index(t => t.PaginaId);
            
            CreateTable(
                "dbo.SugerenciaPagina",
                c => new
                    {
                        PaginaId = c.Int(nullable: false),
                        SugerenciaId = c.Int(nullable: false),
                        Orden = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.PaginaId, t.SugerenciaId })
                .ForeignKey("dbo.Pagina", t => t.PaginaId)
                .ForeignKey("dbo.Sugerencia", t => t.SugerenciaId)
                .Index(t => t.PaginaId)
                .Index(t => t.SugerenciaId);
            
            AddColumn("dbo.Sugerencia", "Eliminado", c => c.Boolean(nullable: false));
            DropColumn("dbo.Sugerencia", "Orden");
            DropColumn("dbo.Sugerencia", "PaginaId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Sugerencia", "PaginaId", c => c.Int(nullable: false));
            AddColumn("dbo.Sugerencia", "Orden", c => c.Int(nullable: false));
            DropForeignKey("dbo.SugerenciaPagina", "SugerenciaId", "dbo.Sugerencia");
            DropForeignKey("dbo.SugerenciaPagina", "PaginaId", "dbo.Pagina");
            DropForeignKey("dbo.Destacado", "PaginaId", "dbo.Pagina");
            DropIndex("dbo.SugerenciaPagina", new[] { "SugerenciaId" });
            DropIndex("dbo.SugerenciaPagina", new[] { "PaginaId" });
            DropIndex("dbo.Destacado", new[] { "PaginaId" });
            DropColumn("dbo.Sugerencia", "Eliminado");
            DropTable("dbo.SugerenciaPagina");
            DropTable("dbo.Destacado");
            CreateIndex("dbo.Sugerencia", "PaginaId");
            AddForeignKey("dbo.Sugerencia", "PaginaId", "dbo.Pagina", "Id");
        }
    }
}
