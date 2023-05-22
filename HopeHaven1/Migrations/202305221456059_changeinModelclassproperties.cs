namespace HopeHaven1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changeinModelclassproperties : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Patients", "Email", c => c.String());
            AddColumn("dbo.Patients", "PhoneNo", c => c.String());
            AddColumn("dbo.Patients", "Amount", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Patients", "Amount");
            DropColumn("dbo.Patients", "PhoneNo");
            DropColumn("dbo.Patients", "Email");
        }
    }
}
