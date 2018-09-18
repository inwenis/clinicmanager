using ClinicManager.Views;

namespace ClinicManager.Services
{
    public interface IDialogService
    {
        void ShowDetailsDialog();
        void CloseDetailsDialog();
        void ShowNewPatientDialog();
        void CloseNewPatientDialog();
    }

    public class DialogService : IDialogService
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
