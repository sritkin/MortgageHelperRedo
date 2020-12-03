namespace MortgageHelperData.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class now : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Mortgage", "Interest", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.Mortgage", "Period", c => c.Int(nullable: false));
            AddColumn("dbo.Mortgage", "Payment", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.Mortgage", "TotalLoanAmount", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.Mortgage", "MonthlyPayment", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            DropColumn("dbo.Mortgage", "Zero");
            DropColumn("dbo.Mortgage", "Five");
            DropColumn("dbo.Mortgage", "Ten");
            DropColumn("dbo.Mortgage", "Fifteen");
            DropColumn("dbo.Mortgage", "Twenty");
            DropColumn("dbo.Mortgage", "TwentyFive");
            DropColumn("dbo.Mortgage", "Thirty");
            DropColumn("dbo.Mortgage", "ThirtyFive");
            DropColumn("dbo.Mortgage", "Forty");
            DropColumn("dbo.Mortgage", "FortyFive");
            DropColumn("dbo.Mortgage", "Fifty");
            DropColumn("dbo.Mortgage", "FiftyFive");
            DropColumn("dbo.Mortgage", "Sixty");
            DropColumn("dbo.Mortgage", "SixtyFive");
            DropColumn("dbo.Mortgage", "Seventy");
            DropColumn("dbo.Mortgage", "SeventyFive");
            DropColumn("dbo.Mortgage", "Eighty");
            DropColumn("dbo.Mortgage", "EightyFive");
            DropColumn("dbo.Mortgage", "Ninety");
            DropColumn("dbo.Mortgage", "NinetyFive");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Mortgage", "NinetyFive", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.Mortgage", "Ninety", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.Mortgage", "EightyFive", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.Mortgage", "Eighty", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.Mortgage", "SeventyFive", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.Mortgage", "Seventy", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.Mortgage", "SixtyFive", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.Mortgage", "Sixty", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.Mortgage", "FiftyFive", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.Mortgage", "Fifty", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.Mortgage", "FortyFive", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.Mortgage", "Forty", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.Mortgage", "ThirtyFive", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.Mortgage", "Thirty", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.Mortgage", "TwentyFive", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.Mortgage", "Twenty", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.Mortgage", "Fifteen", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.Mortgage", "Ten", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.Mortgage", "Five", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.Mortgage", "Zero", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            DropColumn("dbo.Mortgage", "MonthlyPayment");
            DropColumn("dbo.Mortgage", "TotalLoanAmount");
            DropColumn("dbo.Mortgage", "Payment");
            DropColumn("dbo.Mortgage", "Period");
            DropColumn("dbo.Mortgage", "Interest");
        }
    }
}
