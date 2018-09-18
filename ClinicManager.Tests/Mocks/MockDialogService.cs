using ClinicManager.Services;
using System.Collections.Generic;

namespace ClinicManager.Tests.Mocks
{
    public class MockDialogService : IDialogService
    {
        public List<string> InvocationList = new List<string>();

        public void ShowDetailsDialog()
        {
            InvocationList.Add(nameof(ShowDetailsDialog));
        }

        public void CloseDetailsDialog()
        {
            InvocationList.Add(nameof(CloseDetailsDialog));
        }

        public void ShowNewPatientDialog()
        {
            throw new System.NotImplementedException();
        }

        public void CloseNewPatientDialog()
        {
            throw new System.NotImplementedException();
        }
    }
}