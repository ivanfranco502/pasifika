namespace Pasifika.Business.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Arreglo35 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Contacto", "Url", c => c.String(maxLength: 300));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Contacto", "Url");
        }
    }
}
