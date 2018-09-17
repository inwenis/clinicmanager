using System.Windows;
using ClinicManager.Utilities;

namespace ClinicManager.Views
{
    /// <summary>
    /// Interaction logic for PatientDetailView.xaml
    /// </summary>
    public partial class PatientDetailView : Window
    {
        public PatientDetailView()
        {
            InitializeComponent();
            DataContext = ViewModelLocator.PatientDetailViewViewModel;
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
