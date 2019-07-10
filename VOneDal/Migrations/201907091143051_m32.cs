namespace VOneDal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class m32 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Users", "DepartmentId", "dbo.Departments");
            DropForeignKey("dbo.Users", "RoleId", "dbo.Roles");
            DropIndex("dbo.Users", new[] { "RoleId" });
            DropIndex("dbo.Users", new[] { "DepartmentId" });
            RenameColumn(table: "dbo.Users", name: "RoleId", newName: "Role_RoleId");
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
            
            CreateTable(
                "dbo.AccessLevels",
                c => new
                    {
                        AccessLevelId = c.Int(nullable: false, identity: true),
                        DepartmentId = c.Int(nullable: false),
                        RoleId = c.Int(nullable: false),
                        AccessId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.AccessLevelId)
                .ForeignKey("dbo.Accesses", t => t.AccessId, cascadeDelete: true)
                .ForeignKey("dbo.Departments", t => t.DepartmentId, cascadeDelete: true)
                .ForeignKey("dbo.Roles", t => t.RoleId, cascadeDelete: true)
                .Index(t => t.DepartmentId)
                .Index(t => t.RoleId)
                .Index(t => t.AccessId);
            
            AddColumn("dbo.Users", "AccessLevelId", c => c.Int(nullable: false));
            AlterColumn("dbo.Users", "Role_RoleId", c => c.Int());
            CreateIndex("dbo.Users", "AccessLevelId");
            CreateIndex("dbo.Users", "Role_RoleId");
            AddForeignKey("dbo.Users", "AccessLevelId", "dbo.AccessLevels", "AccessLevelId", cascadeDelete: true);
            AddForeignKey("dbo.Users", "Role_RoleId", "dbo.Roles", "RoleId");
            DropColumn("dbo.Users", "DepartmentId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Users", "DepartmentId", c => c.Int(nullable: false));
            DropForeignKey("dbo.Users", "Role_RoleId", "dbo.Roles");
            DropForeignKey("dbo.Users", "AccessLevelId", "dbo.AccessLevels");
            DropForeignKey("dbo.AccessLevels", "RoleId", "dbo.Roles");
            DropForeignKey("dbo.AccessLevels", "DepartmentId", "dbo.Departments");
            DropForeignKey("dbo.AccessLevels", "AccessId", "dbo.Accesses");
            DropIndex("dbo.Users", new[] { "Role_RoleId" });
            DropIndex("dbo.Users", new[] { "AccessLevelId" });
            DropIndex("dbo.AccessLevels", new[] { "AccessId" });
            DropIndex("dbo.AccessLevels", new[] { "RoleId" });
            DropIndex("dbo.AccessLevels", new[] { "DepartmentId" });
            AlterColumn("dbo.Users", "Role_RoleId", c => c.Int(nullable: false));
            DropColumn("dbo.Users", "AccessLevelId");
            DropTable("dbo.AccessLevels");
            DropTable("dbo.Accesses");
            RenameColumn(table: "dbo.Users", name: "Role_RoleId", newName: "RoleId");
            CreateIndex("dbo.Users", "DepartmentId");
            CreateIndex("dbo.Users", "RoleId");
            AddForeignKey("dbo.Users", "RoleId", "dbo.Roles", "RoleId", cascadeDelete: true);
            AddForeignKey("dbo.Users", "DepartmentId", "dbo.Departments", "DepartmentId", cascadeDelete: true);
        }
    }
}
