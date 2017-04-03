namespace Pasifika.Business.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Arreglo31 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Pagina", "Orden", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Pagina", "Orden");
        }
    }
}
