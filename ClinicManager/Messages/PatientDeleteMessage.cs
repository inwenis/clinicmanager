namespace ClinicManager.ViewModels
{
    public class PatientDeleteMessage
    {
        public PatientViewModel ToBeDeleted { get; }

        public PatientDeleteMessage(PatientViewModel toBeDeleted)
        {
            ToBeDeleted = toBeDeleted;
        }
    }
}