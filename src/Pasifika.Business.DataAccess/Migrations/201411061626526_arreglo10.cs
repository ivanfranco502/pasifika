namespace Pasifika.Business.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class arreglo10 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Destino", "Eliminado", c => c.Boolean(nullable: false));
            AddColumn("dbo.Ciudad", "Eliminado", c => c.Boolean(nullable: false));
            AddColumn("dbo.Region", "Eliminado", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Region", "Eliminado");
            DropColumn("dbo.Ciudad", "Eliminado");
            DropColumn("dbo.Destino", "Eliminado");
        }
    }
}
