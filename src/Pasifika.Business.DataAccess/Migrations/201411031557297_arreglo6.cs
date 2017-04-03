namespace Pasifika.Business.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class arreglo6 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Sugerencia", "Orden", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Sugerencia", "Orden");
        }
    }
}
