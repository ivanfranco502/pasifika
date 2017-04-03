namespace Pasifika.Business.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Contacto : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Contacto",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nombre = c.String(maxLength: 150),
                        Apellido = c.String(maxLength: 150),
                        Email = c.String(maxLength: 150),
                        Fecha = c.DateTime(nullable: false),
                        Conocio = c.String(maxLength: 250),
                        Europa = c.Boolean(nullable: false),
                        Pais = c.String(maxLength: 150),
                        Provincia = c.String(maxLength: 150),
                        Sexo = c.String(maxLength: 1),
                        FechaNacimiento = c.DateTime(),
                        Telefono = c.String(maxLength: 50),
                        HoraContacto = c.String(maxLength: 50),
                        Sesion = c.String(maxLength: 300),
                        Mensaje = c.String(maxLength: 2000),
                        Newsletter = c.String(),
                        Tipo = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Contacto");
        }
    }
}
