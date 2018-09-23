using System.Collections.Generic;
using ClinicManager.Models;

namespace ClinicManager.Services
{
    public interface IDoctorDataService
    {
        List<Doctor> GetAllDoctors();
    }
}