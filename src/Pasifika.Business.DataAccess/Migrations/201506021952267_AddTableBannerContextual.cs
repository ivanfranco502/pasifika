namespace Pasifika.Business.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddTableBannerContextual : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BannerContextual",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Foto = c.String(maxLength: 100),
                        Link = c.String(maxLength: 300),
                        Title = c.String(maxLength: 100),
                        Alt = c.String(maxLength: 100),
                        Orden = c.Int(nullable: false),
                        PaginaId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Pagina", t => t.PaginaId)
                .Index(t => t.PaginaId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.BannerContextual", "PaginaId", "dbo.Pagina");
            DropIndex("dbo.BannerContextual", new[] { "PaginaId" });
            DropTable("dbo.BannerContextual");
        }
    }
}
