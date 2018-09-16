using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using Newtonsoft.Json;

namespace ClinicManager
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            PatientsListBox.ItemsSource = LoadFromFile();
        }

        private Patient[] LoadFromFile()
        {
            var allText = File.ReadAllText("samplePatients.json");
            var jsonSerializer = JsonSerializer.Create(new JsonSerializerSettings()
            {
                DateFormatString = "dd/MM/yyyy"
            });
            var patients = jsonSerializer.Deserialize<List<Patient>>(new JsonTextReader(new StringReader(allText)));
            return patients.ToArray();
        }

        private void PatientsListBox_OnSelected(object sender, RoutedEventArgs e)
        {
            EditButton.IsEnabled = true;
            var selectedPatient = (Patient) ((ListBox) sender).SelectedItem;
            NameTextBox.Text = selectedPatient.FirstName + " " + selectedPatient.SecondName;
            EmailTextBox.Text = selectedPatient.Email;
            PhoneTextBox.Text = selectedPatient.PhoneNumber;
            AgeTextBox.Text = (((int) (DateTime.Now - selectedPatient.BirthDate).TotalDays / 365)).ToString();
            InsuranceNumberTextBox.Text = selectedPatient.InsuranceNumber;
            Photo.Source = new BitmapImage(new Uri(selectedPatient.Photo, UriKind.Relative));
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            PatientDetailView detailView = new PatientDetailView();
            detailView.Patient = ((Patient) PatientsListBox.SelectedItem);
            detailView.ShowDialog();
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            PatientDetailView detailView = new PatientDetailView();
            detailView.Patient = ((Patient) PatientsListBox.SelectedItem);
            detailView.ShowDialog();
        }

        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {
            var jsonSerializer = JsonSerializer.Create(new JsonSerializerSettings()
            {
                DateFormatString = "dd/MM/yyyy"
            });
            File.Delete("samplePatients.json");
            using (var streamWriter = new StreamWriter(File.OpenWrite("samplePatients.json")))
            {
                jsonSerializer.Serialize(streamWriter, PatientsListBox.Items);
            }
        }
    }
}
