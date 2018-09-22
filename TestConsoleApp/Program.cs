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
            using (var context = new PatientContext())
            {
                context.Database.Log = Console.WriteLine;

                var allPatients = context.Patients.ToList();

                foreach (var patient in allPatients)
                {
                    Console.WriteLine(JsonConvert.SerializeObject(patient));
                }

//                context.Patients.AddRange(LoadFromFile());

//                context.SaveChanges();
            }

            Console.WriteLine("Press enter to exit");
            Console.ReadLine();
        }

        private static List<Patient> LoadFromFile()
        {
            var allText = File.ReadAllText("samplePatients.json");
            var jsonSerializer = JsonSerializer.Create(new JsonSerializerSettings()
            {
                DateFormatString = "dd/MM/yyyy"
            });
            var patients = jsonSerializer.Deserialize<List<Patient>>(new JsonTextReader(new StringReader(allText)));
            return patients;
        }

    }
}
