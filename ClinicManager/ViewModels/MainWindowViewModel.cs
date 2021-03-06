﻿using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows.Input;
using ClinicManager.Messages;
using ClinicManager.Services;
using ClinicManager.Utilities;

namespace ClinicManager.ViewModels
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        private readonly IDialogService _dialogservice;
        private readonly IPatientDataService _patientDataService;
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
                Messenger.Default.Send(SelectedPatient);
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public ICommand Edit { get; set; }
        public ICommand AddPatient { get; set; }

        public MainWindowViewModel(IDialogService dialogservice, IPatientDataService patientDataService)
        {
            _dialogservice = dialogservice;
            _patientDataService = patientDataService;
            AllPatients = new ObservableCollection<PatientViewModel>();
            LoadData();
            Edit = new CustomCommand(EditExuecute, CanEditExecute);
            AddPatient = new CustomCommand(AddPatientExecute, _ => true);
            Messenger.Default.Register<PatientDeleteMessage>(this, HandlePatientDeleteMessage);
            Messenger.Default.Register<PatientUpdatedMessage>(this, HandlePatientUpdatedMessage);
            Messenger.Default.Register<NewPatientAddedMessage>(this, HandleNewPatientAddedMessage);
        }

        private void HandleNewPatientAddedMessage(NewPatientAddedMessage obj)
        {
            AllPatients.Clear();
            LoadData();
        }

        private void AddPatientExecute(object obj)
        {
            _dialogservice.ShowNewPatientDialog();
        }

        private void HandlePatientUpdatedMessage(PatientUpdatedMessage obj)
        {
            AllPatients.Clear();
            LoadData();
            _dialogservice.CloseDetailsDialog();
        }

        private void HandlePatientDeleteMessage(PatientDeleteMessage message)
        {
            AllPatients.Clear();
            LoadData();
            _dialogservice.CloseDetailsDialog();
        }

        private bool CanEditExecute(object obj)
        {
            return SelectedPatient != null;
        }

        private void EditExuecute(object obj)
        {
            _dialogservice.ShowDetailsDialog();
        }

        private void LoadData()
        {
            var allPatients = _patientDataService.GetAllPatients();
            var viewModels = allPatients.Select(x => PatientViewModel.FromModel(x));
            foreach (var patient in viewModels)
            {
                AllPatients.Add(patient);
            }
        }

    }
}
