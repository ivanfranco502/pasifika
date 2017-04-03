namespace Pasifika.Business.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class paginaTexto : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PaginaTexto",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Texto = c.String(),
                        PaginaId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Pagina", t => t.PaginaId)
                .Index(t => t.PaginaId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PaginaTexto", "PaginaId", "dbo.Pagina");
            DropIndex("dbo.PaginaTexto", new[] { "PaginaId" });
            DropTable("dbo.PaginaTexto");
        }
    }
}
