using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using ClinicManager.DataModel;
using ClinicManager.Models;

namespace ClinicManager.Services
{
    class PatientDataFromDataBaseService : IPatientDataService
    {
        public List<Patient> GetAllPatients()
        {
            using (var context = new PatientContext())
            {
                var allPatients = context.Patients
                    .OrderBy(x => x.SecondName)
                    .ThenBy(x => x.FirstName)
                    .ToList();
                return allPatients;
            }
        }

        public bool DeletePatient(Patient patient)
        {
            using (var context = new PatientContext())
            {
                var patientToBeDeleted = context.Patients.Find(patient.Id);
                if (patientToBeDeleted != null)
                {
                    context.Patients.Remove(patientToBeDeleted);
                    context.SaveChanges();
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public bool UpdatePatient(Patient updatedModel)
        {
            using (var context = new PatientContext())
            {
                context.Patients.Attach(updatedModel);
                context.Entry(updatedModel).State = EntityState.Modified;
                context.SaveChanges();
                return true;
            }
        }

        public void AddNewPatient(Patient model)
        {
            using (var context = new PatientContext())
            {
                context.Patients.Add(model);
                context.SaveChanges();
            }
        }
    }
}