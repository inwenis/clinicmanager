using System.Collections.Generic;
using ClinicManager.Models;

namespace ClinicManager.Services
{
    public interface IPatientDataService
    {
        List<Patient> GetAllPatients();
        bool DeletePatient(Patient patient);
        bool UpdatePatient(Patient updatedModel);
        void AddNewPatient(Patient model);
    }
}