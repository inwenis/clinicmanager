using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace ClinicManager.Views
{
    /// <summary>
    /// Interaction logic for PatientDetailView.xaml
    /// </summary>
    public partial class PatientDetailView : Window
    {
        public Patient Patient { get; set; }

        public PatientDetailView()
        {
            InitializeComponent();
            this.Loaded += DetailView_Loaded;
        }

        void DetailView_Loaded(object sender, RoutedEventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            NameLabel.Content = Patient.FirstName + " " + Patient.SecondName;
            PhoneTextBox.Text = Patient.PhoneNumber;
            EmailTextBox.Text = Patient.Email;
            AgeTextBox.Text = (((int) (DateTime.Now - Patient.BirthDate).TotalDays / 365)).ToString();
            Image.Source = new BitmapImage(new Uri(Patient.Photo, UriKind.Relative));
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
