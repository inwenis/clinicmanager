using ClinicManager.Services;
using ClinicManager.ViewModels;

namespace ClinicManager.Utilities
{
    public static class ViewModelLocator
    {
        public static MainWindowViewModel MainWindowViewModel;
        public static PatientDetailViewViewModel PatientDetailViewViewModel;

        static ViewModelLocator()
        {
            var dialogService = new DialogService();
            var patientDataService = new PatientDataService();

            MainWindowViewModel = new MainWindowViewModel(dialogService, patientDataService);
            PatientDetailViewViewModel = new PatientDetailViewViewModel(patientDataService);
        }
    }
}
