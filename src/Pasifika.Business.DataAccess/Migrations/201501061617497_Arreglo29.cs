namespace Pasifika.Business.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Arreglo29 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Pagina", "RegionId", c => c.Int());
            CreateIndex("dbo.Pagina", "RegionId");
            AddForeignKey("dbo.Pagina", "RegionId", "dbo.Region", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Pagina", "RegionId", "dbo.Region");
            DropIndex("dbo.Pagina", new[] { "RegionId" });
            DropColumn("dbo.Pagina", "RegionId");
        }
    }
}
