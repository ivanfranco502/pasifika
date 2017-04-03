namespace Pasifika.Business.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Wellness : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Viaje", "NombreWellnes", c => c.String(maxLength: 150));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Viaje", "NombreWellnes");
        }
    }
}
