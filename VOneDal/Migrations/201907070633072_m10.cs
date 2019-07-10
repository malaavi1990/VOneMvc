namespace VOneDal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class m10 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Trakts", "ProductId", "dbo.Products");
            DropIndex("dbo.Trakts", new[] { "ProductId" });
            AddColumn("dbo.ProductStatus", "Title", c => c.String());
            AddColumn("dbo.TraktStatus", "Tittle", c => c.String());
            DropColumn("dbo.Trakts", "ProductId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Trakts", "ProductId", c => c.Long(nullable: false));
            DropColumn("dbo.TraktStatus", "Tittle");
            DropColumn("dbo.ProductStatus", "Title");
            CreateIndex("dbo.Trakts", "ProductId");
            AddForeignKey("dbo.Trakts", "ProductId", "dbo.Products", "ProductId", cascadeDelete: true);
        }
    }
}
