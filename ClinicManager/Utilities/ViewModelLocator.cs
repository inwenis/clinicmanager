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

            MainWindowViewModel = new MainWindowViewModel(dialogService);
            PatientDetailViewViewModel = new PatientDetailViewViewModel();
        }
    }
}
