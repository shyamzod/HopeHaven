namespace HopeHaven1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AdminLoginTableAdded1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AdminLogins",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserName = c.String(),
                        Password = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.AdminLogins");
        }
    }
}
