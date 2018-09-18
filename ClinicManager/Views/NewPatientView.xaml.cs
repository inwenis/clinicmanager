using System.Windows;
using ClinicManager.Utilities;

namespace ClinicManager.Views
{
    /// <summary>
    /// Interaction logic for PatientDetailView.xaml
    /// </summary>
    public partial class NewPatientView : Window
    {
        public NewPatientView()
        {
            InitializeComponent();
            DataContext = ViewModelLocator.NewPatientViewModel;
        }
    }
}
