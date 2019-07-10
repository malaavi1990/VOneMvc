namespace VOneDal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class m33 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Users", "Role_RoleId", "dbo.Roles");
            DropIndex("dbo.Users", new[] { "Role_RoleId" });
            DropColumn("dbo.Users", "Role_RoleId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Users", "Role_RoleId", c => c.Int());
            CreateIndex("dbo.Users", "Role_RoleId");
            AddForeignKey("dbo.Users", "Role_RoleId", "dbo.Roles", "RoleId");
        }
    }
}
