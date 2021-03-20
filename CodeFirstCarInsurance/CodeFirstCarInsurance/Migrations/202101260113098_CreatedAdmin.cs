namespace CodeFirstCarInsurance.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreatedAdmin : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Admins",
                c => new
                    {
                        FirstName = c.String(nullable: false, maxLength: 128),
                        LastName = c.String(),
                        Email = c.String(),
                    })
                .PrimaryKey(t => t.FirstName);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Admins");
        }
    }
}
