namespace Pasifika.Business.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Arreglo24 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Nota", "SubTitulo", c => c.String(maxLength: 100));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Nota", "SubTitulo");
        }
    }
}
