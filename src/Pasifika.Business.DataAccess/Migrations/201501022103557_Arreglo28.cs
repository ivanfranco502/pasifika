namespace Pasifika.Business.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Arreglo28 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Region", "Descripcion", c => c.String(maxLength: 100));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Region", "Descripcion");
        }
    }
}
