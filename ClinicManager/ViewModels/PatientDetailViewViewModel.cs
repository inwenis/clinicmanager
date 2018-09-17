using System.ComponentModel;
using System.Windows.Input;
using ClinicManager.Utilities;

namespace ClinicManager.ViewModels
{
    public class PatientDetailViewViewModel : INotifyPropertyChanged
    {
        private PatientViewModel _selectedPatient;
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

        public PatientDetailViewViewModel()
        {
            Delete = new CustomCommand(DeleteExecute, CanDeleteExecute);
            Messenger.Default.Register<PatientViewModel>(this, SetSelectedPatient);
        }

        private bool CanDeleteExecute(object obj)
        {
            return SelectedPatient != null;
        }

        private void DeleteExecute(object obj)
        {
            Messenger.Default.Send(new PatientDeleteMessage(SelectedPatient));
        }

        private void SetSelectedPatient(PatientViewModel message)
        {
            SelectedPatient = message;
        }
    }
}