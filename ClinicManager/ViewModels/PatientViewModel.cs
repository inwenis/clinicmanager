using System;
using ClinicManager.Models;
using System.ComponentModel;

namespace ClinicManager.ViewModels
{
    public class PatientViewModel : INotifyPropertyChanged
    {
        private string _firstName;
        private string _secondName;
        private string _email;
        private DateTimeOffset _birthDate;
        private string _insuranceNumber;
        private string _phoneNumber;
        private string _photo;

        public event PropertyChangedEventHandler PropertyChanged;

        public Patient Model { get; private set; }

        public string Name
        {
            get { return $"{FirstName} {SecondName}"; }
        }

        public int Age
        {
            get
            {
                var age = ComputeSimpleAge(BirthDate);
                return age;
            }
        }

        public string FirstName
        {
            get => _firstName;
            set
            {
                _firstName = value;
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs(nameof(FirstName)));
                    PropertyChanged(this, new PropertyChangedEventArgs(nameof(Name)));
                }
            }
        }

        public string SecondName
        {
            get { return _secondName; }
            set
            {
                _secondName = value;
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs(nameof(SecondName)));
                    PropertyChanged(this, new PropertyChangedEventArgs(nameof(Name)));
                }
            }
        }

        public string Email
        {
            get { return _email; }
            set
            {
                _email = value;
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs(nameof(Email)));
                }
            }
        }

        public DateTimeOffset BirthDate
        {
            get { return _birthDate; }
            set
            {
                _birthDate = value;
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs(nameof(BirthDate)));
                    PropertyChanged(this, new PropertyChangedEventArgs(nameof(Age)));
                }
            }
        }

        public string InsuranceNumber
        {
            get { return _insuranceNumber; }
            set
            {
                _insuranceNumber = value;
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs(nameof(InsuranceNumber)));
                }
            }
        }

        public string PhoneNumber
        {
            get { return _phoneNumber; }
            set
            {
                _phoneNumber = value;
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs(nameof(PhoneNumber)));
                }
            }
        }

        public string Photo
        {
            get { return _photo; }
            set
            {
                _photo = value;
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs(nameof(Photo)));
                }
            }
        }

        private static int ComputeSimpleAge(DateTimeOffset birthDate)
        {
            var today = DateTime.Today;
            var age = today.Year - birthDate.Year;
            if (birthDate > today.AddYears(-age)) age--;
            return age;
        }

        public static PatientViewModel FromModel(Patient model)
        {
            var viewModel = new PatientViewModel
            {
                BirthDate = model.BirthDate,
                Email = model.Email,
                FirstName = model.FirstName,
                InsuranceNumber = model.InsuranceNumber,
                Model = model,
                PhoneNumber = model.PhoneNumber,
                Photo = model.Photo,
                SecondName = model.SecondName
            };
            return viewModel;
        }
    }
}