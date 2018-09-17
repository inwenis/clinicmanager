using System.ComponentModel;
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

        public PatientDetailViewViewModel()
        {
            Messenger.Default.Register<PatientViewModel>(this, SetSelectedPatient);
        }

        private void SetSelectedPatient(PatientViewModel message)
        {
            SelectedPatient = message;
        }
    }
}