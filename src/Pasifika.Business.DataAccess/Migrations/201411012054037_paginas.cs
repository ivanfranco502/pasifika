namespace Pasifika.Business.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class paginas : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Banner",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Texto = c.String(),
                        Foto = c.String(),
                        Link = c.String(),
                        Title = c.String(),
                        Alt = c.String(),
                        PaginaId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Pagina", t => t.PaginaId)
                .Index(t => t.PaginaId);
            
            CreateTable(
                "dbo.Pagina",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SeccionId = c.Int(),
                        DestinoId = c.Int(),
                        TagId = c.Int(),
                        ViajeId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Destino", t => t.DestinoId)
                .ForeignKey("dbo.Seccion", t => t.SeccionId)
                .ForeignKey("dbo.Tag", t => t.TagId)
                .ForeignKey("dbo.Viaje", t => t.ViajeId)
                .Index(t => t.SeccionId)
                .Index(t => t.DestinoId)
                .Index(t => t.TagId)
                .Index(t => t.ViajeId);
            
            CreateTable(
                "dbo.InfoRelacion",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Titulo1 = c.String(),
                        Foto1 = c.String(),
                        SubTitulo1 = c.String(),
                        Texto1 = c.String(),
                        Link1 = c.String(),
                        Titulo2 = c.String(),
                        Foto2 = c.String(),
                        SubTitulo2 = c.String(),
                        Texto2 = c.String(),
                        Link2 = c.String(),
                        Titulo3 = c.String(),
                        Foto3 = c.String(),
                        SubTitulo3 = c.String(),
                        Texto3 = c.String(),
                        Link3 = c.String(),
                        Titulo4 = c.String(),
                        Foto4 = c.String(),
                        SubTitulo4 = c.String(),
                        Texto4 = c.String(),
                        Link4 = c.String(),
                        Titulo5 = c.String(),
                        Foto5 = c.String(),
                        SubTitulo5 = c.String(),
                        Texto5 = c.String(),
                        Link5 = c.String(),
                        Titulo6 = c.String(),
                        Foto6 = c.String(),
                        SubTitulo6 = c.String(),
                        Texto6 = c.String(),
                        Link6 = c.String(),
                        PaginaId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Pagina", t => t.PaginaId)
                .Index(t => t.PaginaId);
            
            CreateTable(
                "dbo.MetaTag",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Description = c.String(),
                        Keywords = c.String(),
                        PaginaId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Pagina", t => t.PaginaId)
                .Index(t => t.PaginaId);
            
            CreateTable(
                "dbo.Seccion",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Nombre = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Sugerencia",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Titulo = c.String(),
                        Foto = c.String(),
                        SubTitulo = c.String(),
                        Link = c.String(),
                        PaginaId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Pagina", t => t.PaginaId)
                .Index(t => t.PaginaId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Pagina", "ViajeId", "dbo.Viaje");
            DropForeignKey("dbo.Pagina", "TagId", "dbo.Tag");
            DropForeignKey("dbo.Sugerencia", "PaginaId", "dbo.Pagina");
            DropForeignKey("dbo.Pagina", "SeccionId", "dbo.Seccion");
            DropForeignKey("dbo.MetaTag", "PaginaId", "dbo.Pagina");
            DropForeignKey("dbo.InfoRelacion", "PaginaId", "dbo.Pagina");
            DropForeignKey("dbo.Pagina", "DestinoId", "dbo.Destino");
            DropForeignKey("dbo.Banner", "PaginaId", "dbo.Pagina");
            DropIndex("dbo.Sugerencia", new[] { "PaginaId" });
            DropIndex("dbo.MetaTag", new[] { "PaginaId" });
            DropIndex("dbo.InfoRelacion", new[] { "PaginaId" });
            DropIndex("dbo.Pagina", new[] { "ViajeId" });
            DropIndex("dbo.Pagina", new[] { "TagId" });
            DropIndex("dbo.Pagina", new[] { "DestinoId" });
            DropIndex("dbo.Pagina", new[] { "SeccionId" });
            DropIndex("dbo.Banner", new[] { "PaginaId" });
            DropTable("dbo.Sugerencia");
            DropTable("dbo.Seccion");
            DropTable("dbo.MetaTag");
            DropTable("dbo.InfoRelacion");
            DropTable("dbo.Pagina");
            DropTable("dbo.Banner");
        }
    }
}
