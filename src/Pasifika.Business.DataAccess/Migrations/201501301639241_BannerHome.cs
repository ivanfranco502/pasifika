namespace Pasifika.Business.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class BannerHome : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BannerHome",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Texto = c.String(maxLength: 100),
                        Texto2 = c.String(maxLength: 100),
                        TextoBoton = c.String(maxLength: 100),
                        Foto = c.String(maxLength: 300),
                        Link = c.String(maxLength: 300),
                        Alt = c.String(maxLength: 100),
                        Mostrar = c.Boolean(nullable: false),
                        Eliminado = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.BannerHome");
        }
    }
}
