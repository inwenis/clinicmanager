using System.Collections.Generic;
using System.IO;
using System.Reflection;
using ClinicManager.Models;
using Newtonsoft.Json;

namespace ClinicManager.Services
{
    public class PatientDataService
    {
        public Patient[] GetAllPatients()
        {
            var allPatientsFromFile = LoadFromFile();
            return allPatientsFromFile;
        }

        public bool DeletePatient(Patient patient)
        {
            return false;
        }

        public bool UpdatePatient(Patient patient)
        {
            return false;
        }

        private Patient[] LoadFromFile()
        {
            var allText = File.ReadAllText("SampleData/samplePatients.json");
            var jsonSerializer = JsonSerializer.Create(new JsonSerializerSettings()
            {
                DateFormatString = "dd/MM/yyyy"
            });
            var patients = jsonSerializer.Deserialize<List<Patient>>(new JsonTextReader(new StringReader(allText)));
            var applicationDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            foreach (var patient in patients)
            {
                patient.Photo = Path.Combine("..", "Photos", patient.Photo);
            }
            return patients.ToArray();
        }

    }
}
