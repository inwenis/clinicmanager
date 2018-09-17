﻿using System.IO;
using System.Windows;
using ClinicManager.ViewModels;
using Newtonsoft.Json;

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
            DataContext = new MainWindowViewModel();
            EditButton.IsEnabled = false;
            EditMenuItem.IsEnabled = false;
        }

        private void PatientsListBox_OnSelected(object sender, RoutedEventArgs e)
        {
            EditButton.IsEnabled = true;
            EditMenuItem.IsEnabled = true;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var patientDetailViewViewModel = new PatientDetailViewViewModel();
            patientDetailViewViewModel.SelectedPatient = ((MainWindowViewModel) DataContext).SelectedPatient;
            PatientDetailView detailView = new PatientDetailView(patientDetailViewViewModel);
            detailView.ShowDialog();
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            var patientDetailViewViewModel = new PatientDetailViewViewModel();
            patientDetailViewViewModel.SelectedPatient = ((MainWindowViewModel) DataContext).SelectedPatient;
            PatientDetailView detailView = new PatientDetailView(patientDetailViewViewModel);
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
