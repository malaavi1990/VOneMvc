namespace VOneDal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class m34 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AccessLevels", "Name", c => c.String());
            AddColumn("dbo.AccessLevels", "Title", c => c.String());
            AddColumn("dbo.AccessLevels", "Description", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.AccessLevels", "Description");
            DropColumn("dbo.AccessLevels", "Title");
            DropColumn("dbo.AccessLevels", "Name");
        }
    }
}
