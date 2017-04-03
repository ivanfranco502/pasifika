namespace Pasifika.Business.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Arreglo33 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Destino", "Orden", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Destino", "Orden");
        }
    }
}
