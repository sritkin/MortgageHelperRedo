namespace MortgageHelperData.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class massproducechange : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Mortgage", "UserID", c => c.Guid(nullable: false));
            AddColumn("dbo.Rating", "UserID", c => c.Guid(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Rating", "UserID");
            DropColumn("dbo.Mortgage", "UserID");
        }
    }
}
