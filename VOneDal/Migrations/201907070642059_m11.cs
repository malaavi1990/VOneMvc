namespace VOneDal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class m11 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Plants",
                c => new
                    {
                        PlantId = c.Int(nullable: false, identity: true),
                        PlantName = c.String(),
                        ParentId = c.Int(nullable: false),
                        Description = c.String(),
                        DateOfEstablishment = c.DateTime(nullable: false),
                        CreateDate = c.DateTime(nullable: false),
                        ImageUrl = c.String(),
                        PlantTypeId = c.Int(nullable: false),
                        PlantStatusId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PlantId)
                .ForeignKey("dbo.PlantStatus", t => t.PlantStatusId, cascadeDelete: true)
                .ForeignKey("dbo.PlantTypes", t => t.PlantTypeId, cascadeDelete: true)
                .Index(t => t.PlantTypeId)
                .Index(t => t.PlantStatusId);
            
            CreateTable(
                "dbo.PlantDetails",
                c => new
                    {
                        PlantDetailsId = c.Int(nullable: false, identity: true),
                        ShiftTime = c.String(),
                        Address = c.String(),
                        PostalCode = c.String(),
                        PhoneNumber = c.String(),
                        LatLocation = c.String(),
                        LongLocation = c.String(),
                        PlantId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PlantDetailsId)
                .ForeignKey("dbo.Plants", t => t.PlantId, cascadeDelete: true)
                .Index(t => t.PlantId);
            
            CreateTable(
                "dbo.PlantStatus",
                c => new
                    {
                        PlantStatusId = c.Int(nullable: false, identity: true),
                        PlantStatusName = c.String(),
                        Title = c.String(),
                    })
                .PrimaryKey(t => t.PlantStatusId);
            
            CreateTable(
                "dbo.PlantTypes",
                c => new
                    {
                        PlantTypeId = c.Int(nullable: false, identity: true),
                        PlantTypeName = c.String(),
                        Title = c.String(),
                    })
                .PrimaryKey(t => t.PlantTypeId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Plants", "PlantTypeId", "dbo.PlantTypes");
            DropForeignKey("dbo.Plants", "PlantStatusId", "dbo.PlantStatus");
            DropForeignKey("dbo.PlantDetails", "PlantId", "dbo.Plants");
            DropIndex("dbo.PlantDetails", new[] { "PlantId" });
            DropIndex("dbo.Plants", new[] { "PlantStatusId" });
            DropIndex("dbo.Plants", new[] { "PlantTypeId" });
            DropTable("dbo.PlantTypes");
            DropTable("dbo.PlantStatus");
            DropTable("dbo.PlantDetails");
            DropTable("dbo.Plants");
        }
    }
}
