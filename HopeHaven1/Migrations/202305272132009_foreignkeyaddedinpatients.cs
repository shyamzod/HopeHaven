namespace HopeHaven1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class foreignkeyaddedinpatients : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Patients", "TherapistId", c => c.Int());
            CreateIndex("dbo.Patients", "TherapistId");
            AddForeignKey("dbo.Patients", "TherapistId", "dbo.Therapists", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Patients", "TherapistId", "dbo.Therapists");
            DropIndex("dbo.Patients", new[] { "TherapistId" });
            DropColumn("dbo.Patients", "TherapistId");
        }
    }
}
