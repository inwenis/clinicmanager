﻿using System.Collections.Generic;
using System.IO;
using System.Linq;
using ClinicManager.Models;
using Newtonsoft.Json;

namespace ClinicManager.Services
{
    public interface IPatientDataService
    {
        List<Patient> GetAllPatients();
        bool DeletePatient(Patient patient);
        bool UpdatePatient(Patient updatedModel);
        void AddNewPatient(Patient model);
    }

    public class PatientDataService : IPatientDataService
    {
        private string _dataFile = "SampleData/samplePatients.json";

        public List<Patient> GetAllPatients()
        {
            var allPatientsFromFile = LoadFromFile();
            return allPatientsFromFile;
        }

        public bool DeletePatient(Patient patient)
        {
            var allPatientsFromFile = LoadFromFile();
            var patientToBeDeleted = allPatientsFromFile
                .SingleOrDefault(x => x.InsuranceNumber == patient.InsuranceNumber);
            if (patientToBeDeleted == null) // did not find patient to be deleted
            {
                return false;
            }
            else
            {
                allPatientsFromFile.Remove(patientToBeDeleted);
                SaveAll(allPatientsFromFile);
                return true;
            }
        }

        public bool UpdatePatient(Patient updatedModel)
        {
            var allPatients = GetAllPatients();
            var oldModel = allPatients
                .SingleOrDefault(x => x.InsuranceNumber == updatedModel.InsuranceNumber);
            if (oldModel != null)
            {
                var index = allPatients.IndexOf(oldModel);
                allPatients.Insert(index, updatedModel);
                allPatients.Remove(oldModel);
                SaveAll(allPatients);
                return true;
            }
            else
            {
                return false;
            }
        }

        public void AddNewPatient(Patient model)
        {
            var allPatients = GetAllPatients();
            allPatients.Insert(0, model);
            SaveAll(allPatients);
        }

        private List<Patient> LoadFromFile()
        {
            var allText = File.ReadAllText(_dataFile);
            var jsonSerializer = JsonSerializer.Create(new JsonSerializerSettings()
            {
                DateFormatString = "dd/MM/yyyy"
            });
            var patients = jsonSerializer.Deserialize<List<Patient>>(new JsonTextReader(new StringReader(allText)));
            return patients;
        }

        private void SaveAll(List<Patient> allPatientsFromFile)
        {
            var jsonSerializer = JsonSerializer.Create(new JsonSerializerSettings()
            {
                DateFormatString = "dd/MM/yyyy",
                Formatting = Formatting.Indented
            });
            File.Delete(_dataFile);
            using (var streamWriter = new StreamWriter(File.OpenWrite(_dataFile)))
            {
                jsonSerializer.Serialize(streamWriter, allPatientsFromFile);
            }
        }

    }
}
