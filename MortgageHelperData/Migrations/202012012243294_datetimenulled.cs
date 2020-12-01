namespace MortgageHelperData.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class datetimenulled : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Property", "TimeOnMarket", c => c.DateTimeOffset(nullable: false, precision: 7));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Property", "TimeOnMarket", c => c.DateTime(nullable: false));
        }
    }
}
