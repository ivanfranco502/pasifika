namespace Pasifika.Business.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Arreglo37 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Destino", "PDFGuia", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Destino", "PDFGuia");
        }
    }
}
