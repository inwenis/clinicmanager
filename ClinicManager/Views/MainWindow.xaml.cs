using System.Windows;
using ClinicManager.Utilities;

namespace ClinicManager.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = ViewModelLocator.MainWindowViewModel;
        }

        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {
        }
    }
}
