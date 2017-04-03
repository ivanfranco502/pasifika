namespace Pasifika.Business.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class promociones : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Promocion",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Titulo = c.String(),
                        Foto = c.String(),
                        SubTitulo = c.String(),
                        Link = c.String(),
                        Promo = c.String(),
                        Eliminado = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Promocion");
        }
    }
}
