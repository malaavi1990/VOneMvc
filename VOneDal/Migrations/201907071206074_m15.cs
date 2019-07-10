namespace VOneDal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class m15 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.TraktTypes", "Title", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.TraktTypes", "Title");
        }
    }
}
