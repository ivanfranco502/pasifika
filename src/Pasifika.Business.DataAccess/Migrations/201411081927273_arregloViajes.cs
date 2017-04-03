namespace Pasifika.Business.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class arregloViajes : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Viaje", "InformacionGeneral", c => c.String());
            AddColumn("dbo.Viaje", "Importante", c => c.String());
            AddColumn("dbo.Viaje", "Condicion", c => c.String());
            DropColumn("dbo.Viaje", "algo");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Viaje", "algo", c => c.String());
            DropColumn("dbo.Viaje", "Condicion");
            DropColumn("dbo.Viaje", "Importante");
            DropColumn("dbo.Viaje", "InformacionGeneral");
        }
    }
}
