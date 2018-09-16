using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Reflection;
using ClinicManager.Models;
using Newtonsoft.Json;

namespace ClinicManager.ViewModels
{
    public class MainWindowViewModel
    {
        private ObservableCollection<Patient> _allPatients;

        public ObservableCollection<Patient> AllPatients
        {
            get => _allPatients;
            set => _allPatients = value;
        }

        public MainWindowViewModel()
        {
            AllPatients = new ObservableCollection<Patient>();
            LoadData();
        }

        private void LoadData()
        {
            var allPatients = LoadFromFile();
            foreach (var patient in allPatients)
            {
                AllPatients.Add(patient);
            }
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
