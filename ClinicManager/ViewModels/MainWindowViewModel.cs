﻿using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Reflection;
using ClinicManager.Models;
using Newtonsoft.Json;

namespace ClinicManager.ViewModels
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<PatientViewModel> _allPatients;
        private PatientViewModel _selectedPatient;

        public ObservableCollection<PatientViewModel> AllPatients
        {
            get => _allPatients;
            set => _allPatients = value;
        }

        public PatientViewModel SelectedPatient
        {
            get => _selectedPatient;
            set
            {
                _selectedPatient = value;
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs(nameof(SelectedPatient)));
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public MainWindowViewModel()
        {
            AllPatients = new ObservableCollection<PatientViewModel>();
            LoadData();
        }

        private void LoadData()
        {
            var allPatients = LoadFromFile();
            var viewModels = allPatients.Select(x => PatientViewModel.FromModel(x));
            foreach (var patient in viewModels)
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
