namespace Pasifika.Business.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Arreglo38 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Viaje", "TituloCuadro", c => c.String(maxLength: 100));
            AddColumn("dbo.Viaje", "TextoCuadro", c => c.String(maxLength: 300));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Viaje", "TextoCuadro");
            DropColumn("dbo.Viaje", "TituloCuadro");
        }
    }
}
