namespace RADicalAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class HighScoreAdded : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "HighScore", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "HighScore");
        }
    }
}
