namespace VOneDal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class m12 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Plants", "PlantStatusId", "dbo.PlantStatus");
            DropForeignKey("dbo.Plants", "PlantTypeId", "dbo.PlantTypes");
            DropForeignKey("dbo.Trakts", "TraktTypeId", "dbo.TraktTypes");
            DropPrimaryKey("dbo.PlantStatus");
            DropPrimaryKey("dbo.PlantTypes");
            DropPrimaryKey("dbo.TraktTypes");
            CreateTable(
                "dbo.PlantJoinTrakts",
                c => new
                    {
                        PlantJoinTraktId = c.Long(nullable: false, identity: true),
                        TraktId = c.Long(nullable: false),
                        PlantId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PlantJoinTraktId)
                .ForeignKey("dbo.Plants", t => t.PlantId, cascadeDelete: true)
                .ForeignKey("dbo.Trakts", t => t.TraktId, cascadeDelete: true)
                .Index(t => t.TraktId)
                .Index(t => t.PlantId);
            
            AddColumn("dbo.Users", "PlantId", c => c.Int(nullable: false));
            AlterColumn("dbo.PlantStatus", "PlantStatusId", c => c.Int(nullable: false));
            AlterColumn("dbo.PlantTypes", "PlantTypeId", c => c.Int(nullable: false));
            AlterColumn("dbo.TraktTypes", "TraktTypeId", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.PlantStatus", "PlantStatusId");
            AddPrimaryKey("dbo.PlantTypes", "PlantTypeId");
            AddPrimaryKey("dbo.TraktTypes", "TraktTypeId");
            CreateIndex("dbo.Users", "PlantId");
            AddForeignKey("dbo.Users", "PlantId", "dbo.Plants", "PlantId", cascadeDelete: true);
            AddForeignKey("dbo.Plants", "PlantStatusId", "dbo.PlantStatus", "PlantStatusId", cascadeDelete: true);
            AddForeignKey("dbo.Plants", "PlantTypeId", "dbo.PlantTypes", "PlantTypeId", cascadeDelete: true);
            AddForeignKey("dbo.Trakts", "TraktTypeId", "dbo.TraktTypes", "TraktTypeId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Trakts", "TraktTypeId", "dbo.TraktTypes");
            DropForeignKey("dbo.Plants", "PlantTypeId", "dbo.PlantTypes");
            DropForeignKey("dbo.Plants", "PlantStatusId", "dbo.PlantStatus");
            DropForeignKey("dbo.Users", "PlantId", "dbo.Plants");
            DropForeignKey("dbo.PlantJoinTrakts", "TraktId", "dbo.Trakts");
            DropForeignKey("dbo.PlantJoinTrakts", "PlantId", "dbo.Plants");
            DropIndex("dbo.Users", new[] { "PlantId" });
            DropIndex("dbo.PlantJoinTrakts", new[] { "PlantId" });
            DropIndex("dbo.PlantJoinTrakts", new[] { "TraktId" });
            DropPrimaryKey("dbo.TraktTypes");
            DropPrimaryKey("dbo.PlantTypes");
            DropPrimaryKey("dbo.PlantStatus");
            AlterColumn("dbo.TraktTypes", "TraktTypeId", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.PlantTypes", "PlantTypeId", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.PlantStatus", "PlantStatusId", c => c.Int(nullable: false, identity: true));
            DropColumn("dbo.Users", "PlantId");
            DropTable("dbo.PlantJoinTrakts");
            AddPrimaryKey("dbo.TraktTypes", "TraktTypeId");
            AddPrimaryKey("dbo.PlantTypes", "PlantTypeId");
            AddPrimaryKey("dbo.PlantStatus", "PlantStatusId");
            AddForeignKey("dbo.Trakts", "TraktTypeId", "dbo.TraktTypes", "TraktTypeId", cascadeDelete: true);
            AddForeignKey("dbo.Plants", "PlantTypeId", "dbo.PlantTypes", "PlantTypeId", cascadeDelete: true);
            AddForeignKey("dbo.Plants", "PlantStatusId", "dbo.PlantStatus", "PlantStatusId", cascadeDelete: true);
        }
    }
}
