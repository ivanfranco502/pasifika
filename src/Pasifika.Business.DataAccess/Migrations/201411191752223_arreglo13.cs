namespace Pasifika.Business.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class arreglo13 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Destino", "Datos", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Destino", "Datos");
        }
    }
}
