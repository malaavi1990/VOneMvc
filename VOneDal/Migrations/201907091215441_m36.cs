namespace VOneDal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class m36 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.AccessLevels", "AccessId", "dbo.Accesses");
            DropIndex("dbo.AccessLevels", new[] { "AccessId" });
            AddColumn("dbo.AccessLevels", "ReadAccess", c => c.Boolean(nullable: false));
            AddColumn("dbo.AccessLevels", "WriteAccess", c => c.Boolean(nullable: false));
            AddColumn("dbo.AccessLevels", "DeleteAccess", c => c.Boolean(nullable: false));
            DropColumn("dbo.AccessLevels", "AccessId");
            DropTable("dbo.Accesses");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Accesses",
                c => new
                    {
                        AccessId = c.Int(nullable: false, identity: true),
                        Read = c.Boolean(nullable: false),
                        Write = c.Boolean(nullable: false),
                        Delete = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.AccessId);
            
            AddColumn("dbo.AccessLevels", "AccessId", c => c.Int(nullable: false));
            DropColumn("dbo.AccessLevels", "DeleteAccess");
            DropColumn("dbo.AccessLevels", "WriteAccess");
            DropColumn("dbo.AccessLevels", "ReadAccess");
            CreateIndex("dbo.AccessLevels", "AccessId");
            AddForeignKey("dbo.AccessLevels", "AccessId", "dbo.Accesses", "AccessId", cascadeDelete: true);
        }
    }
}
