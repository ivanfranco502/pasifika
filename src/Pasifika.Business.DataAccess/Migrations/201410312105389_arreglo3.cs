namespace Pasifika.Business.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class arreglo3 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Foto", "Orden", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Foto", "Orden");
        }
    }
}
