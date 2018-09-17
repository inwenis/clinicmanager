using System.ComponentModel;
using System.Windows.Input;
using ClinicManager.Messages;
using ClinicManager.Services;
using ClinicManager.Utilities;

namespace ClinicManager.ViewModels
{
    public class PatientDetailViewViewModel : INotifyPropertyChanged
    {
        private PatientViewModel _selectedPatient;
        private PatientDataService _patientDataService;

        public event PropertyChangedEventHandler PropertyChanged;

        public PatientViewModel SelectedPatient
        {
            get { return _selectedPatient; }
            set
            {
                _selectedPatient = value;
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs(nameof(SelectedPatient)));
                }
            }
        }

        public ICommand Delete { get; set; }
        public ICommand Save { get; set; }

        public PatientDetailViewViewModel(PatientDataService patientDataService)
        {
            _patientDataService = patientDataService;
            Delete = new CustomCommand(DeleteExecute, CanDeleteExecute);
            Save = new CustomCommand(SaveExecute, CanSaveExecute);
            Messenger.Default.Register<PatientViewModel>(this, SetSelectedPatient);
        }

        private bool CanSaveExecute(object obj)
        {
            return SelectedPatient != null; // add .AnyUnSavedChanges();
        }

        private void SaveExecute(object obj)
        {
            var model = SelectedPatient.ToModel();
            var updateWasSuccessful = _patientDataService.UpdatePatient(model);
            if (updateWasSuccessful)
            {
                Messenger.Default.Send(new PatientUpdatedMessage());
            }
        }

        private bool CanDeleteExecute(object obj)
        {
            return SelectedPatient != null;
        }

        private void DeleteExecute(object obj)
        {
            var deletionWasSuccessful = _patientDataService.DeletePatient(SelectedPatient.Model);
            if (deletionWasSuccessful)
            {
                Messenger.Default.Send(new PatientDeleteMessage(SelectedPatient));
            }
        }

        private void SetSelectedPatient(PatientViewModel message)
        {
            if (message != null)
            {
                var patientViewModeCopy = PatientViewModel.FromModel(message.Model);
                SelectedPatient = patientViewModeCopy;
            }
            else
            {
                SelectedPatient = null;
            }
        }
    }
}