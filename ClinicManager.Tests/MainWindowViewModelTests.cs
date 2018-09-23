using System.Linq;
using ClinicManager.Tests.Mocks;
using ClinicManager.Utilities;
using ClinicManager.ViewModels;
using NUnit.Framework;

namespace ClinicManager.Tests
{
    [TestFixture]
    public class MainWindowViewModelTests
    {
        [OneTimeSetUp]
        public void InitializeMapper()
        {
            App.InitializeMapper();
        }

        [Test]
        public void Constructor_LoadsAllPatients()
        {
            var mockDialogService = new MockDialogService();
            var mockPatientDataService = new MockPatientDataService();
            var expected = mockPatientDataService.GetAllPatients();

            var sut = new MainWindowViewModel(mockDialogService, mockPatientDataService);
            var result = sut.AllPatients.Select(x => x.Model);

            CollectionAssert.AreEqual(expected, result);
        }

        [Test]
        public void Edit_CanExecute_WhenNoPatientIsSelected_ReturnsFalse()
        {
            var mockDialogService = new MockDialogService();
            var mockPatientDataService = new MockPatientDataService();
            var sut = new MainWindowViewModel(mockDialogService, mockPatientDataService);
            
            var result = sut.Edit.CanExecute(null);

            Assert.IsFalse(result);
        }

        [Test]
        public void Edit_CanExecute_WhenPatientIsSelected_ReturnsTrue()
        {
            var mockDialogService = new MockDialogService();
            var mockPatientDataService = new MockPatientDataService();
            var sut = new MainWindowViewModel(mockDialogService, mockPatientDataService);
            sut.SelectedPatient = sut.AllPatients.First();
            
            var result = sut.Edit.CanExecute(null);

            Assert.IsTrue(result);
        }

        [Test]
        public void Edit_Execute_OpensPatientDetailsDialog()
        {
            var mockDialogService = new MockDialogService();
            var mockPatientDataService = new MockPatientDataService();
            var sut = new MainWindowViewModel(mockDialogService, mockPatientDataService);
            sut.SelectedPatient = sut.AllPatients.First();
            sut.Edit.Execute(null);

            var firstMethocCall = mockDialogService.InvocationList.First();

            Assert.AreEqual(nameof(mockDialogService.ShowDetailsDialog), firstMethocCall);
        }

        [Test]
        public void HandlePatientDeletedMessage_ClosesPatientDetailsDialog()
        {
            var mockDialogService = new MockDialogService();
            var mockPatientDataService = new MockPatientDataService();
            var sut = new MainWindowViewModel(mockDialogService, mockPatientDataService);
            var dummyPatientViewModel = new PatientViewModel();
            
            Messenger.Default.Send(new PatientDeleteMessage(dummyPatientViewModel));

            var firstMethocCall = mockDialogService.InvocationList.First();
            Assert.AreEqual(nameof(mockDialogService.CloseDetailsDialog), firstMethocCall);
        }
    }
}
