namespace Pasifika.Business.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Arreglo23 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Partner", "Link", c => c.String(maxLength: 500));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Partner", "Link");
        }
    }
}
