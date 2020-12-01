namespace MortgageHelperData.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Feature",
                c => new
                    {
                        FeatureID = c.Int(nullable: false, identity: true),
                        PropertyID = c.Int(),
                        DistanceFromPopulace = c.Decimal(nullable: false, precision: 18, scale: 2),
                        RoadAccess = c.Boolean(nullable: false),
                        CityWater = c.Boolean(nullable: false),
                        CityElectric = c.Boolean(nullable: false),
                        CitySewer = c.Boolean(nullable: false),
                        Internet = c.Boolean(nullable: false),
                        AlternateWater = c.Boolean(nullable: false),
                        AlternateElectric = c.Boolean(nullable: false),
                        AlternateSewage = c.Boolean(nullable: false),
                        BodyOfWater = c.Boolean(nullable: false),
                        NearbyBodyOfWater = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.FeatureID)
                .ForeignKey("dbo.Property", t => t.PropertyID)
                .Index(t => t.PropertyID);
            
            CreateTable(
                "dbo.Property",
                c => new
                    {
                        PropertyID = c.Int(nullable: false, identity: true),
                        UserID = c.Guid(nullable: false),
                        Name = c.String(nullable: false),
                        Address = c.String(nullable: false),
                        Size = c.Double(nullable: false),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Seller = c.String(nullable: false),
                        TimeOnMarket = c.DateTime(nullable: false),
                        PropertyType = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.PropertyID);
            
            CreateTable(
                "dbo.Mortgage",
                c => new
                    {
                        MortgageID = c.Int(nullable: false, identity: true),
                        PropertyID = c.Int(),
                        Zero = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Five = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Ten = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Fifteen = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Twenty = c.Decimal(nullable: false, precision: 18, scale: 2),
                        TwentyFive = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Thirty = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ThirtyFive = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Forty = c.Decimal(nullable: false, precision: 18, scale: 2),
                        FortyFive = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Fifty = c.Decimal(nullable: false, precision: 18, scale: 2),
                        FiftyFive = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Sixty = c.Decimal(nullable: false, precision: 18, scale: 2),
                        SixtyFive = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Seventy = c.Decimal(nullable: false, precision: 18, scale: 2),
                        SeventyFive = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Eighty = c.Decimal(nullable: false, precision: 18, scale: 2),
                        EightyFive = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Ninety = c.Decimal(nullable: false, precision: 18, scale: 2),
                        NinetyFive = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.MortgageID)
                .ForeignKey("dbo.Property", t => t.PropertyID)
                .Index(t => t.PropertyID);
            
            CreateTable(
                "dbo.Rating",
                c => new
                    {
                        RatingID = c.Int(nullable: false, identity: true),
                        PropertyID = c.Int(),
                        FeatureID = c.Int(),
                        RatingTally = c.Decimal(nullable: false, precision: 18, scale: 2),
                        RatingActual = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.RatingID)
                .ForeignKey("dbo.Feature", t => t.PropertyID)
                .ForeignKey("dbo.Property", t => t.PropertyID)
                .Index(t => t.PropertyID);
            
            CreateTable(
                "dbo.IdentityRole",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.IdentityUserRole",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(),
                        IdentityRole_Id = c.String(maxLength: 128),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.IdentityRole", t => t.IdentityRole_Id)
                .ForeignKey("dbo.ApplicationUser", t => t.ApplicationUser_Id)
                .Index(t => t.IdentityRole_Id)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.ApplicationUser",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.IdentityUserClaim",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ApplicationUser", t => t.ApplicationUser_Id)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.IdentityUserLogin",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        LoginProvider = c.String(),
                        ProviderKey = c.String(),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.ApplicationUser", t => t.ApplicationUser_Id)
                .Index(t => t.ApplicationUser_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.IdentityUserRole", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.IdentityUserLogin", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.IdentityUserClaim", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.IdentityUserRole", "IdentityRole_Id", "dbo.IdentityRole");
            DropForeignKey("dbo.Rating", "PropertyID", "dbo.Property");
            DropForeignKey("dbo.Rating", "PropertyID", "dbo.Feature");
            DropForeignKey("dbo.Mortgage", "PropertyID", "dbo.Property");
            DropForeignKey("dbo.Feature", "PropertyID", "dbo.Property");
            DropIndex("dbo.IdentityUserLogin", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserClaim", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserRole", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserRole", new[] { "IdentityRole_Id" });
            DropIndex("dbo.Rating", new[] { "PropertyID" });
            DropIndex("dbo.Mortgage", new[] { "PropertyID" });
            DropIndex("dbo.Feature", new[] { "PropertyID" });
            DropTable("dbo.IdentityUserLogin");
            DropTable("dbo.IdentityUserClaim");
            DropTable("dbo.ApplicationUser");
            DropTable("dbo.IdentityUserRole");
            DropTable("dbo.IdentityRole");
            DropTable("dbo.Rating");
            DropTable("dbo.Mortgage");
            DropTable("dbo.Property");
            DropTable("dbo.Feature");
        }
    }
}
