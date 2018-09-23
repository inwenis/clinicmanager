namespace ClinicManager.DataModel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class add_doctors : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Doctors",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        SecondName = c.String(),
                        Email = c.String(),
                        BirthDate = c.DateTimeOffset(nullable: false, precision: 7),
                        PhoneNumber = c.String(),
                        Photo = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Patients",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        SecondName = c.String(),
                        Email = c.String(),
                        BirthDate = c.DateTimeOffset(nullable: false, precision: 7),
                        InsuranceNumber = c.String(),
                        PhoneNumber = c.String(),
                        Photo = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Patients");
            DropTable("dbo.Doctors");
        }
    }
}
