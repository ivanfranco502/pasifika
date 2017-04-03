namespace Pasifika.Business.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class arreglo9 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Viaje", "Orden", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Viaje", "Orden");
        }
    }
}
