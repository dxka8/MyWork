namespace Admin.Demo.Core.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddBieCuoLe : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Asds", "BieCuole", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Asds", "BieCuole");
        }
    }
}
