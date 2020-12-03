namespace MortgageHelperData.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class first : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Rating", "FeatureID", c => c.Int());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Rating", "FeatureID", c => c.Int(nullable: false));
        }
    }
}
