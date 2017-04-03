namespace Pasifika.Business.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Arreglo27 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Region", "Url", c => c.String(maxLength: 100));
            AddColumn("dbo.Region", "Orden", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Region", "Orden");
            DropColumn("dbo.Region", "Url");
        }
    }
}
