namespace VOneDal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class m20 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.TraktCategories", "Title", c => c.String(nullable: false, maxLength: 250));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.TraktCategories", "Title", c => c.String());
        }
    }
}
