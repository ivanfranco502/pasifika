namespace Pasifika.Business.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class arreglo11 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Destino", "Foto", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Destino", "Foto");
        }
    }
}
