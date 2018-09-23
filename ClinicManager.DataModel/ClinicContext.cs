using System.Data.Entity;
using ClinicManager.Models;

namespace ClinicManager.DataModel
{
    public class ClinicContext : DbContext
    {
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
    }
}
