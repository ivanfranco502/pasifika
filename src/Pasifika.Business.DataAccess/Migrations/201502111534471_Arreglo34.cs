namespace Pasifika.Business.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Arreglo34 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Contacto", "Newsletter", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Contacto", "Newsletter", c => c.String());
        }
    }
}
