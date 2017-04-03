namespace Pasifika.Business.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Arreglo22 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Destino", "Url", c => c.String(maxLength: 100));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Destino", "Url");
        }
    }
}
