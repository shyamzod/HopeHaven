namespace HopeHaven1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class passwordfieldaddedfortherapistsclass : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Therapists", "Password", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Therapists", "Password");
        }
    }
}
