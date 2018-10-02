namespace ClinicManager.DataModel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class adddoctortopatient : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Patients", "AssignedDoctor_Id", c => c.Int());
            CreateIndex("dbo.Patients", "AssignedDoctor_Id");
            AddForeignKey("dbo.Patients", "AssignedDoctor_Id", "dbo.Doctors", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Patients", "AssignedDoctor_Id", "dbo.Doctors");
            DropIndex("dbo.Patients", new[] { "AssignedDoctor_Id" });
            DropColumn("dbo.Patients", "AssignedDoctor_Id");
        }
    }
}
