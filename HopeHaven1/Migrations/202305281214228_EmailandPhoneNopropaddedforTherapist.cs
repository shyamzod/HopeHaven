namespace HopeHaven1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EmailandPhoneNopropaddedforTherapist : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Therapists", "Email", c => c.String());
            AddColumn("dbo.Therapists", "PhoneNo", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Therapists", "PhoneNo");
            DropColumn("dbo.Therapists", "Email");
        }
    }
}
