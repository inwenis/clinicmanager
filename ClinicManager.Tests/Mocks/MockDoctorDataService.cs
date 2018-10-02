using System.Collections.Generic;
using ClinicManager.Models;
using ClinicManager.Services;

namespace ClinicManager.Tests.Mocks
{
    public class MockDoctorDataService : IDoctorDataService
    {
        public List<Doctor> GetAllDoctors()
        {
            var allTestDoctors = new List<Doctor>
            {
                new Doctor()
                {
                    FirstName = "Test",
                    SecondName = "Doc_1"
                },
            };
            return allTestDoctors;
        }
    }
}