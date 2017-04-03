namespace Pasifika.Business.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class arreglo21 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Viaje", "InfoPrecio", c => c.String(maxLength: 100));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Viaje", "InfoPrecio");
        }
    }
}
