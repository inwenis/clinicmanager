using System.Data.Entity;
using ClinicManager.Models;

namespace ClinicManager.DataModel
{
    public class PatientContext : DbContext
    {
        public DbSet<Patient> Patients { get; set; }
    }
}
