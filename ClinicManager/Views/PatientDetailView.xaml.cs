using System.Windows;
using ClinicManager.Utilities;
using ClinicManager.ViewModels;

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

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
