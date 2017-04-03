namespace Pasifika.Business.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class arreglo4 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ViajeTag", "Orden", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.ViajeTag", "Orden");
        }
    }
}
