using System.ComponentModel;

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
    }
}