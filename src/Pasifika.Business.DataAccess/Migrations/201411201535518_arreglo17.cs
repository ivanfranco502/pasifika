namespace Pasifika.Business.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class arreglo17 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Destino", "Alt", c => c.String());
            AddColumn("dbo.Sugerencia", "Alt", c => c.String());
            AddColumn("dbo.Partner", "Alt", c => c.String());
            AddColumn("dbo.Prensa", "Alt", c => c.String());
            AddColumn("dbo.Promocion", "Alt", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Promocion", "Alt");
            DropColumn("dbo.Prensa", "Alt");
            DropColumn("dbo.Partner", "Alt");
            DropColumn("dbo.Sugerencia", "Alt");
            DropColumn("dbo.Destino", "Alt");
        }
    }
}
