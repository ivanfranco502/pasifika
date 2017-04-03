namespace Pasifika.Business.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class arreglo19 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.InfoRelacion", "Titulo2", c => c.String(maxLength: 100));
            AlterColumn("dbo.InfoRelacion", "Foto2", c => c.String(maxLength: 300));
            AlterColumn("dbo.InfoRelacion", "Alt2", c => c.String(maxLength: 100));
            AlterColumn("dbo.InfoRelacion", "Link2", c => c.String(maxLength: 300));
            AlterColumn("dbo.InfoRelacion", "Titulo3", c => c.String(maxLength: 100));
            AlterColumn("dbo.InfoRelacion", "Foto3", c => c.String(maxLength: 300));
            AlterColumn("dbo.InfoRelacion", "Alt3", c => c.String(maxLength: 100));
            AlterColumn("dbo.InfoRelacion", "Link3", c => c.String(maxLength: 300));
            AlterColumn("dbo.InfoRelacion", "Titulo4", c => c.String(maxLength: 100));
            AlterColumn("dbo.InfoRelacion", "Foto4", c => c.String(maxLength: 300));
            AlterColumn("dbo.InfoRelacion", "Alt4", c => c.String(maxLength: 100));
            AlterColumn("dbo.InfoRelacion", "Link4", c => c.String(maxLength: 300));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.InfoRelacion", "Link4", c => c.String());
            AlterColumn("dbo.InfoRelacion", "Alt4", c => c.String());
            AlterColumn("dbo.InfoRelacion", "Foto4", c => c.String());
            AlterColumn("dbo.InfoRelacion", "Titulo4", c => c.String());
            AlterColumn("dbo.InfoRelacion", "Link3", c => c.String());
            AlterColumn("dbo.InfoRelacion", "Alt3", c => c.String());
            AlterColumn("dbo.InfoRelacion", "Foto3", c => c.String());
            AlterColumn("dbo.InfoRelacion", "Titulo3", c => c.String());
            AlterColumn("dbo.InfoRelacion", "Link2", c => c.String());
            AlterColumn("dbo.InfoRelacion", "Alt2", c => c.String());
            AlterColumn("dbo.InfoRelacion", "Foto2", c => c.String());
            AlterColumn("dbo.InfoRelacion", "Titulo2", c => c.String());
        }
    }
}
