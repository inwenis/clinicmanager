using System;
using System.ComponentModel;
using System.Windows.Input;
using ClinicManager.Messages;
using ClinicManager.Services;
using ClinicManager.Utilities;

namespace ClinicManager.ViewModels
{
    public class NewPatientViewModel : INotifyPropertyChanged
    {
        private DialogService _dialogService;
        private PatientDataService _patientDataService;
        public PatientViewModel NewPatient { get; set; }

        public ICommand Save { get; set; }
        public ICommand Cancel { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        public NewPatientViewModel(DialogService dialogService, PatientDataService patientDataService)
        {
            _dialogService = dialogService;
            _patientDataService = patientDataService;
            NewPatient = new PatientViewModel();
            Save = new CustomCommand(SaveExecute, CanSaveExecute);
            Cancel = new CustomCommand(CancelExecute, _ => true);
        }

        private void CancelExecute(object obj)
        {
            _dialogService.CloseNewPatientDialog();
        }

        private bool CanSaveExecute(object obj)
        {
            bool IsNullOrWhiteSpace(string text)
            {
                return text == null || text.Trim() == string.Empty;
            }

            var areAllMandatoryPropertiesSet = !IsNullOrWhiteSpace(NewPatient.FirstName) &&
                                               !IsNullOrWhiteSpace(NewPatient.SecondName) &&
                                               !IsNullOrWhiteSpace(NewPatient.InsuranceNumber);
            return areAllMandatoryPropertiesSet;
        }

        private void SaveExecute(object obj)
        {
            if (NewPatient.BirthDate == default(DateTimeOffset))
            {
                NewPatient.BirthDate = DateTimeOffset.Now;
            }

            if (NewPatient.Photo == null)
            {
                NewPatient.Photo = string.Empty;
            }
            _patientDataService.AddNewPatient(NewPatient.ToModel());
            Messenger.Default.Send(new NewPatientAddedMessage());
            _dialogService.CloseNewPatientDialog();
        }
    }
}