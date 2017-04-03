namespace Pasifika.Business.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class arreglo7 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.InfoRelacion", "Titulo5");
            DropColumn("dbo.InfoRelacion", "Foto5");
            DropColumn("dbo.InfoRelacion", "SubTitulo5");
            DropColumn("dbo.InfoRelacion", "Texto5");
            DropColumn("dbo.InfoRelacion", "Link5");
            DropColumn("dbo.InfoRelacion", "Titulo6");
            DropColumn("dbo.InfoRelacion", "Foto6");
            DropColumn("dbo.InfoRelacion", "SubTitulo6");
            DropColumn("dbo.InfoRelacion", "Texto6");
            DropColumn("dbo.InfoRelacion", "Link6");
        }
        
        public override void Down()
        {
            AddColumn("dbo.InfoRelacion", "Link6", c => c.String());
            AddColumn("dbo.InfoRelacion", "Texto6", c => c.String());
            AddColumn("dbo.InfoRelacion", "SubTitulo6", c => c.String());
            AddColumn("dbo.InfoRelacion", "Foto6", c => c.String());
            AddColumn("dbo.InfoRelacion", "Titulo6", c => c.String());
            AddColumn("dbo.InfoRelacion", "Link5", c => c.String());
            AddColumn("dbo.InfoRelacion", "Texto5", c => c.String());
            AddColumn("dbo.InfoRelacion", "SubTitulo5", c => c.String());
            AddColumn("dbo.InfoRelacion", "Foto5", c => c.String());
            AddColumn("dbo.InfoRelacion", "Titulo5", c => c.String());
        }
    }
}
