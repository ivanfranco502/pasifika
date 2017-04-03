namespace Pasifika.Business.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Arreglo25 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Pagina", "NotaId", c => c.Int());
            CreateIndex("dbo.Pagina", "NotaId");
            AddForeignKey("dbo.Pagina", "NotaId", "dbo.Nota", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Pagina", "NotaId", "dbo.Nota");
            DropIndex("dbo.Pagina", new[] { "NotaId" });
            DropColumn("dbo.Pagina", "NotaId");
        }
    }
}
