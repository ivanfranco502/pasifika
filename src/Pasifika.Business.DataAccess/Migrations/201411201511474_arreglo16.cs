namespace Pasifika.Business.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class arreglo16 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Viaje", "AltImagenListado", c => c.String());
            AddColumn("dbo.Foto", "Alt", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Foto", "Alt");
            DropColumn("dbo.Viaje", "AltImagenListado");
        }
    }
}
