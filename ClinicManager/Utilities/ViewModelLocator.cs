using ClinicManager.ViewModels;

namespace ClinicManager.Utilities
{
    public static class ViewModelLocator
    {
        public static MainWindowViewModel MainWindowViewModel;
        public static PatientDetailViewViewModel PatientDetailViewViewModel;

        static ViewModelLocator()
        {
            MainWindowViewModel = new MainWindowViewModel();
            PatientDetailViewViewModel = new PatientDetailViewViewModel();
        }
    }
}
