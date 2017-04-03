namespace Pasifika.Business.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class arreglo15 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Banner", "Texto2", c => c.String());
            AddColumn("dbo.Destacado", "Alt", c => c.String());
            AddColumn("dbo.InfoRelacion", "Alt1", c => c.String());
            AddColumn("dbo.InfoRelacion", "Alt2", c => c.String());
            AddColumn("dbo.InfoRelacion", "Alt3", c => c.String());
            AddColumn("dbo.InfoRelacion", "Alt4", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.InfoRelacion", "Alt4");
            DropColumn("dbo.InfoRelacion", "Alt3");
            DropColumn("dbo.InfoRelacion", "Alt2");
            DropColumn("dbo.InfoRelacion", "Alt1");
            DropColumn("dbo.Destacado", "Alt");
            DropColumn("dbo.Banner", "Texto2");
        }
    }
}
