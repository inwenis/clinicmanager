using System.Collections.Generic;
using ClinicManager.Models;
using ClinicManager.Services;

namespace ClinicManager.Tests.Mocks
{
    public class MockPatientDataService : IPatientDataService
    {
        private List<Patient> allTestPatients;

        public MockPatientDataService()
        {
            allTestPatients = new List<Patient>
            {
                new Patient()
                {
                    FirstName = "Test",
                    SecondName = "Patient_1"
                },
                new Patient()
                {
                    FirstName = "Test",
                    SecondName = "Patient_2"
                }
            };
        }

        public List<Patient> GetAllPatients()
        {
            return allTestPatients;
        }

        public bool DeletePatient(Patient patient)
        {
            throw new System.NotImplementedException();
        }

        public bool UpdatePatient(Patient updatedModel)
        {
            throw new System.NotImplementedException();
        }

        public void AddNewPatient(Patient model)
        {
            throw new System.NotImplementedException();
        }
    }
}