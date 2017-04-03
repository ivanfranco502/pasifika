namespace Pasifika.Business.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class arreglo5 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Banner", "Orden", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Banner", "Orden");
        }
    }
}
