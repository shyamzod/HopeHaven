namespace HopeHaven1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class paymentpendingpropaddedinPatientmodel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Patients", "IsPaymentDone", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Patients", "IsPaymentDone");
        }
    }
}
