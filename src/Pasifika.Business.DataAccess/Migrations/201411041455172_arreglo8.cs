namespace Pasifika.Business.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class arreglo8 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Tag", "Texto", c => c.String());
            AddColumn("dbo.Tag", "Eliminado", c => c.Boolean(nullable: false));
            AddColumn("dbo.Viaje", "Eliminado", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Viaje", "Eliminado");
            DropColumn("dbo.Tag", "Eliminado");
            DropColumn("dbo.Tag", "Texto");
        }
    }
}
