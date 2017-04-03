namespace Pasifika.Business.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class arreglo14 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Destacado", "SubTitulo2", c => c.String());
            AddColumn("dbo.Sugerencia", "SubTitulo2", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Sugerencia", "SubTitulo2");
            DropColumn("dbo.Destacado", "SubTitulo2");
        }
    }
}
