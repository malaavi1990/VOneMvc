namespace VOneDal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        ProductId = c.Long(nullable: false, identity: true),
                        Title = c.String(),
                        Description = c.String(),
                        Text = c.String(),
                        CreateDate = c.DateTime(nullable: false),
                        ImageUrl = c.String(),
                        HaveSlider = c.Boolean(nullable: false),
                        SliderImageUrl = c.String(),
                        Price = c.String(),
                        IsDeleted = c.Boolean(nullable: false),
                        VisitCount = c.Int(nullable: false),
                        UserId = c.Int(nullable: false),
                        ProductCategoryId = c.Int(nullable: false),
                        ProductStatusId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ProductId)
                .ForeignKey("dbo.ProductCategories", t => t.ProductCategoryId, cascadeDelete: true)
                .ForeignKey("dbo.ProductStatus", t => t.ProductStatusId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.ProductCategoryId)
                .Index(t => t.ProductStatusId);
            
            CreateTable(
                "dbo.ProductCategories",
                c => new
                    {
                        ProductCategoryId = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        ParentId = c.Int(),
                        CreateDate = c.DateTime(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.ProductCategoryId);
            
            CreateTable(
                "dbo.ProductGalleries",
                c => new
                    {
                        ProductGalleryId = c.Long(nullable: false, identity: true),
                        ImageUrl = c.String(),
                        Title = c.String(),
                        CreateDate = c.DateTime(nullable: false),
                        ProductId = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.ProductGalleryId)
                .ForeignKey("dbo.Products", t => t.ProductId, cascadeDelete: true)
                .Index(t => t.ProductId);
            
            CreateTable(
                "dbo.ProductStatus",
                c => new
                    {
                        ProductStatusId = c.Int(nullable: false),
                        ProductStatusName = c.String(),
                    })
                .PrimaryKey(t => t.ProductStatusId);
            
            CreateTable(
                "dbo.ProductTags",
                c => new
                    {
                        ProductTagId = c.Long(nullable: false, identity: true),
                        TagTitle = c.String(),
                        CreateDate = c.DateTime(nullable: false),
                        ProductId = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.ProductTagId)
                .ForeignKey("dbo.Products", t => t.ProductId, cascadeDelete: true)
                .Index(t => t.ProductId);
            
            CreateTable(
                "dbo.Trakts",
                c => new
                    {
                        TraktId = c.Long(nullable: false, identity: true),
                        TraktTitle = c.String(),
                        Description = c.String(),
                        ImageUrl = c.String(),
                        IsActive = c.Boolean(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        VisitCount = c.Int(nullable: false),
                        CreateDate = c.DateTime(nullable: false),
                        Text = c.String(),
                        FromDate = c.DateTime(nullable: false),
                        ToDate = c.DateTime(nullable: false),
                        TraktCategoryId = c.Int(nullable: false),
                        ProductId = c.Long(nullable: false),
                        TraktTypeId = c.Int(nullable: false),
                        TraktStatusId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.TraktId)
                .ForeignKey("dbo.Products", t => t.ProductId, cascadeDelete: true)
                .ForeignKey("dbo.TraktCategories", t => t.TraktCategoryId, cascadeDelete: true)
                .ForeignKey("dbo.TraktStatus", t => t.TraktStatusId, cascadeDelete: true)
                .ForeignKey("dbo.TraktTypes", t => t.TraktTypeId, cascadeDelete: true)
                .Index(t => t.TraktCategoryId)
                .Index(t => t.ProductId)
                .Index(t => t.TraktTypeId)
                .Index(t => t.TraktStatusId);
            
            CreateTable(
                "dbo.TraktCategories",
                c => new
                    {
                        TraktCategoryId = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        CreateDate = c.DateTime(nullable: false),
                        ParentId = c.Int(),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.TraktCategoryId);
            
            CreateTable(
                "dbo.TraktStatus",
                c => new
                    {
                        TraktStatusId = c.Int(nullable: false),
                        TraktStatusName = c.String(),
                    })
                .PrimaryKey(t => t.TraktStatusId);
            
            CreateTable(
                "dbo.TraktTags",
                c => new
                    {
                        TraktTagId = c.Long(nullable: false, identity: true),
                        TagTitle = c.String(),
                        CreateDate = c.DateTime(nullable: false),
                        TraktId = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.TraktTagId)
                .ForeignKey("dbo.Trakts", t => t.TraktId, cascadeDelete: true)
                .Index(t => t.TraktId);
            
            CreateTable(
                "dbo.TraktTypes",
                c => new
                    {
                        TraktTypeId = c.Int(nullable: false, identity: true),
                        TraktTypeName = c.String(),
                    })
                .PrimaryKey(t => t.TraktTypeId);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        UserId = c.Int(nullable: false, identity: true),
                        UserName = c.String(),
                        FullName = c.String(),
                        Email = c.String(),
                        Password = c.String(),
                        Address = c.String(),
                        RegisterDate = c.DateTime(nullable: false),
                        LastLogin = c.DateTime(nullable: false),
                        FaildLoginCount = c.Int(nullable: false),
                        ActiveCode = c.String(),
                        EmailConfirm = c.Boolean(nullable: false),
                        MobileNumber = c.String(),
                        MobileConfirm = c.Boolean(nullable: false),
                        IsLock = c.Boolean(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        ProfileImage = c.String(),
                        RoleId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.Roles", t => t.RoleId, cascadeDelete: true)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.Roles",
                c => new
                    {
                        RoleId = c.Int(nullable: false),
                        RoleName = c.String(),
                        Title = c.String(),
                    })
                .PrimaryKey(t => t.RoleId);
            
            CreateTable(
                "dbo.Settings",
                c => new
                    {
                        SettingId = c.Int(nullable: false, identity: true),
                        SiteTitle = c.String(),
                        IconUrl = c.String(),
                        CopyRight = c.String(),
                        KeyWord = c.String(),
                        Description = c.String(),
                        LogoUrl = c.String(),
                    })
                .PrimaryKey(t => t.SettingId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Users", "RoleId", "dbo.Roles");
            DropForeignKey("dbo.Products", "UserId", "dbo.Users");
            DropForeignKey("dbo.Trakts", "TraktTypeId", "dbo.TraktTypes");
            DropForeignKey("dbo.TraktTags", "TraktId", "dbo.Trakts");
            DropForeignKey("dbo.Trakts", "TraktStatusId", "dbo.TraktStatus");
            DropForeignKey("dbo.Trakts", "TraktCategoryId", "dbo.TraktCategories");
            DropForeignKey("dbo.Trakts", "ProductId", "dbo.Products");
            DropForeignKey("dbo.ProductTags", "ProductId", "dbo.Products");
            DropForeignKey("dbo.Products", "ProductStatusId", "dbo.ProductStatus");
            DropForeignKey("dbo.ProductGalleries", "ProductId", "dbo.Products");
            DropForeignKey("dbo.Products", "ProductCategoryId", "dbo.ProductCategories");
            DropIndex("dbo.Users", new[] { "RoleId" });
            DropIndex("dbo.TraktTags", new[] { "TraktId" });
            DropIndex("dbo.Trakts", new[] { "TraktStatusId" });
            DropIndex("dbo.Trakts", new[] { "TraktTypeId" });
            DropIndex("dbo.Trakts", new[] { "ProductId" });
            DropIndex("dbo.Trakts", new[] { "TraktCategoryId" });
            DropIndex("dbo.ProductTags", new[] { "ProductId" });
            DropIndex("dbo.ProductGalleries", new[] { "ProductId" });
            DropIndex("dbo.Products", new[] { "ProductStatusId" });
            DropIndex("dbo.Products", new[] { "ProductCategoryId" });
            DropIndex("dbo.Products", new[] { "UserId" });
            DropTable("dbo.Settings");
            DropTable("dbo.Roles");
            DropTable("dbo.Users");
            DropTable("dbo.TraktTypes");
            DropTable("dbo.TraktTags");
            DropTable("dbo.TraktStatus");
            DropTable("dbo.TraktCategories");
            DropTable("dbo.Trakts");
            DropTable("dbo.ProductTags");
            DropTable("dbo.ProductStatus");
            DropTable("dbo.ProductGalleries");
            DropTable("dbo.ProductCategories");
            DropTable("dbo.Products");
        }
    }
}
