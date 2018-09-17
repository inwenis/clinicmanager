namespace ClinicManager.ViewModels
{
    internal class PatientDeleteMessage
    {
        public PatientViewModel ToBeDeleted { get; }

        public PatientDeleteMessage(PatientViewModel toBeDeleted)
        {
            ToBeDeleted = toBeDeleted;
        }
    }
}