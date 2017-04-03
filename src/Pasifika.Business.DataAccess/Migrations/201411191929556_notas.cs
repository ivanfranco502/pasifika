namespace Pasifika.Business.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class notas : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Nota",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Titulo = c.String(),
                        Resumen = c.String(),
                        Url = c.String(),
                        Fecha = c.DateTime(nullable: false),
                        Visible = c.Boolean(nullable: false),
                        EnPrensa = c.Boolean(nullable: false),
                        Eliminado = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Nota");
        }
    }
}
