namespace Pasifika.Business.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Arreglo36 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Destino", "FotoGuia", c => c.String(maxLength: 300));
            AddColumn("dbo.Destino", "FotoHotel", c => c.String());
            AddColumn("dbo.Destino", "FotoExcursion", c => c.String());
            DropColumn("dbo.Destino", "Foto");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Destino", "Foto", c => c.String(maxLength: 300));
            DropColumn("dbo.Destino", "FotoExcursion");
            DropColumn("dbo.Destino", "FotoHotel");
            DropColumn("dbo.Destino", "FotoGuia");
        }
    }
}
