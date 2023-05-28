namespace HopeHaven1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedprofilepicpropfortherapist : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Therapists", "profilePhoto", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Therapists", "profilePhoto");
        }
    }
}
