namespace MortgageHelperData.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addeduserguid : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Property", "UserID", c => c.Guid(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Property", "UserID");
        }
    }
}
