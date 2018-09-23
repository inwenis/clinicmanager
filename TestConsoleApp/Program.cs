using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using ClinicManager.DataModel;
using ClinicManager.Models;
using Newtonsoft.Json;

namespace TestConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var context = new ClinicContext())
            {
                context.Database.Log = Console.WriteLine;
                context.Patients.AddRange(LoadPatientsFromFile());
                context.Doctors.AddRange(LoadDoctorsFromFile());
                context.SaveChanges();
            }

            Console.WriteLine("Press enter to exit");
            Console.ReadLine();
        }

        private static List<Patient> LoadPatientsFromFile()
        {
            var allText = File.ReadAllText("samplePatients.json");
            var jsonSerializer = JsonSerializer.Create(new JsonSerializerSettings()
            {
                DateFormatString = "dd/MM/yyyy"
            });
            var patients = jsonSerializer.Deserialize<List<Patient>>(new JsonTextReader(new StringReader(allText)));
            return patients;
        }

        private static List<Doctor> LoadDoctorsFromFile()
        {
            var allText = File.ReadAllText("sampleDoctors.json");
            var jsonSerializer = JsonSerializer.Create(new JsonSerializerSettings()
            {
                DateFormatString = "dd/MM/yyyy"
            });
            var doctors = jsonSerializer.Deserialize<List<Doctor>>(new JsonTextReader(new StringReader(allText)));
            return doctors;
        }
    }
}