namespace CodeFirstCarInsurance.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateInsuranceQualificationTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.InsuranceQualifications",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Age = c.Int(nullable: false),
                        DUI = c.Boolean(nullable: false),
                        SpeedingTickets = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.InsuranceQualifications");
        }
    }
}
