namespace Pasifika.Business.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Arreglo32 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Pagina", "Eliminado", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Pagina", "Eliminado");
        }
    }
}
