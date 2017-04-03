namespace Pasifika.Business.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Arreglo30 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Ciudad", "Url", c => c.String(maxLength: 100));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Ciudad", "Url");
        }
    }
}
