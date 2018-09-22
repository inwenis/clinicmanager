using ClinicManager.Services;
using ClinicManager.ViewModels;

namespace ClinicManager.Utilities
{
    public static class ViewModelLocator
    {
        public static MainWindowViewModel MainWindowViewModel;
        public static PatientDetailViewViewModel PatientDetailViewViewModel;
        public static NewPatientViewModel NewPatientViewModel;

        static ViewModelLocator()
        {
            var dialogService = new DialogService();
            var patientDataService = new PatientDataFromDataBaseService();

            MainWindowViewModel = new MainWindowViewModel(dialogService, patientDataService);
            PatientDetailViewViewModel = new PatientDetailViewViewModel(patientDataService);
            NewPatientViewModel = new NewPatientViewModel(dialogService, patientDataService);
        }
    }
}
