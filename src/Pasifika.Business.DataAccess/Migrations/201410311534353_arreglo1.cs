namespace Pasifika.Business.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class arreglo1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Viaje", "Descrpcion", c => c.String());
            AddColumn("dbo.Viaje", "Precio", c => c.Int(nullable: false));
            AddColumn("dbo.Viaje", "Referencia", c => c.String());
            AddColumn("dbo.Viaje", "PDF", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Viaje", "PDF");
            DropColumn("dbo.Viaje", "Referencia");
            DropColumn("dbo.Viaje", "Precio");
            DropColumn("dbo.Viaje", "Descrpcion");
        }
    }
}
