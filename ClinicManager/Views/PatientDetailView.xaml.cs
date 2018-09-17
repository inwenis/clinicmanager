using System.Windows;
using ClinicManager.ViewModels;

namespace ClinicManager.Views
{
    /// <summary>
    /// Interaction logic for PatientDetailView.xaml
    /// </summary>
    public partial class PatientDetailView : Window
    {
        public PatientDetailView(PatientDetailViewViewModel viewModel)
        {
            InitializeComponent();
            DataContext = viewModel;
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
