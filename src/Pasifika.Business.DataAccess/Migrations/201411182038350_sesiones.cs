namespace Pasifika.Business.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class sesiones : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.FormularioSesion",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nombre = c.String(),
                        Orden = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.FormularioSesion");
        }
    }
}
