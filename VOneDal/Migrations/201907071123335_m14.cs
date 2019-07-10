namespace VOneDal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class m14 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Trakts", "HaveSlider", c => c.Boolean(nullable: false));
            AddColumn("dbo.Trakts", "SliderImageUrl", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Trakts", "SliderImageUrl");
            DropColumn("dbo.Trakts", "HaveSlider");
        }
    }
}
