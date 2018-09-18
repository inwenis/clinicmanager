using ClinicManager.Views;

namespace ClinicManager.Services
{
    public class DialogService
    {
        private PatientDetailView _patientDetailView;
        private NewPatientView _newPatientView;

        public void ShowDetailsDialog()
        {
            _patientDetailView = new PatientDetailView();
            _patientDetailView.ShowDialog();
        }

        public void CloseDetailsDialog()
        {
            _patientDetailView.Close();
        }

        public void ShowNewPatientDialog()
        {
            _newPatientView = new NewPatientView();
            _newPatientView.ShowDialog();
        }

        public void CloseNewPatientDialog()
        {
            _newPatientView.Close();
        }
    }
}
