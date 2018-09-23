using System.Collections.Generic;
using System.Linq;
using ClinicManager.DataModel;
using ClinicManager.Models;

namespace ClinicManager.Services
{
    class DoctorDataService : IDoctorDataService
    {
        public List<Doctor> GetAllDoctors()
        {
            using (var context = new ClinicContext())
            {
                var allDoctors = context.Doctors
                    .OrderBy(x => x.SecondName)
                    .ThenBy(x => x.FirstName)
                    .ToList();
                return allDoctors;
            }
        }
    }
}