namespace Pasifika.Business.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class arreglo12 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Viaje", "Descripcion", c => c.String());
            DropColumn("dbo.Viaje", "Descrpcion");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Viaje", "Descrpcion", c => c.String());
            DropColumn("dbo.Viaje", "Descripcion");
        }
    }
}
