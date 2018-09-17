using ClinicManager.Views;

namespace ClinicManager.Services
{
    public class DialogService
    {
        private PatientDetailView _patientDetailView;

        public void ShowDetailsDialog()
        {
            _patientDetailView = new PatientDetailView();
            _patientDetailView.ShowDialog();
        }

        public void CloseDetailsDialog()
        {
            _patientDetailView.Close();
        }
    }
}
