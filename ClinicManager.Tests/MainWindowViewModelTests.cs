﻿using System.Linq;
using ClinicManager.Tests.Mocks;
using ClinicManager.ViewModels;
using NUnit.Framework;

namespace ClinicManager.Tests
{
    [TestFixture]
    public class MainWindowViewModelTests
    {
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
    }
}
