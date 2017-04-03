namespace Pasifika.Business.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class tags : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ViajeTag",
                c => new
                    {
                        TagId = c.Int(nullable: false),
                        ViajeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.TagId, t.ViajeId })
                .ForeignKey("dbo.Tag", t => t.TagId)
                .ForeignKey("dbo.Viaje", t => t.ViajeId)
                .Index(t => t.TagId)
                .Index(t => t.ViajeId);
            
            CreateTable(
                "dbo.Tag",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nombre = c.String(),
                        Url = c.String(),
                        Descripcion = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ViajeTag", "ViajeId", "dbo.Viaje");
            DropForeignKey("dbo.ViajeTag", "TagId", "dbo.Tag");
            DropIndex("dbo.ViajeTag", new[] { "ViajeId" });
            DropIndex("dbo.ViajeTag", new[] { "TagId" });
            DropTable("dbo.Tag");
            DropTable("dbo.ViajeTag");
        }
    }
}
