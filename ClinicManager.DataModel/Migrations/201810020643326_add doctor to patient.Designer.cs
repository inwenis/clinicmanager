// <auto-generated />
namespace ClinicManager.DataModel.Migrations
{
    using System.CodeDom.Compiler;
    using System.Data.Entity.Migrations;
    using System.Data.Entity.Migrations.Infrastructure;
    using System.Resources;
    
    [GeneratedCode("EntityFramework.Migrations", "6.2.0-61023")]
    public sealed partial class adddoctortopatient : IMigrationMetadata
    {
        private readonly ResourceManager Resources = new ResourceManager(typeof(adddoctortopatient));
        
        string IMigrationMetadata.Id
        {
            get { return "201810020643326_add doctor to patient"; }
        }
        
        string IMigrationMetadata.Source
        {
            get { return null; }
        }
        
        string IMigrationMetadata.Target
        {
            get { return Resources.GetString("Target"); }
        }
    }
}
