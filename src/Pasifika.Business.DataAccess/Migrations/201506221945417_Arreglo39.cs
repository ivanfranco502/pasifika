namespace Pasifika.Business.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Arreglo39 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Viaje", "InfoPrecio", c => c.String(maxLength: 200));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Viaje", "InfoPrecio", c => c.String(maxLength: 100));
        }
    }
}
