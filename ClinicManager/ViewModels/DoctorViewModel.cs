using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using AutoMapper;
using ClinicManager.Models;

namespace ClinicManager.ViewModels
{
    public class DoctorViewModel
    {
        private string _firstName;
        private string _secondName;
        private string _email;
        private DateTimeOffset _birthDate;
        private string _phoneNumber;
        private string _photoPath;

        public event PropertyChangedEventHandler PropertyChanged;

        public Doctor Model { get; private set; }

        public int Id { get; set; }

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

        public string PhotoPath
        {
            get { return _photoPath; }
            set
            {
                _photoPath = value;
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs(nameof(PhotoPath)));
                }
            }
        }

        public ImageSource Photo
        {
            get
            {
                if (PhotoPath != "not yet set")
                {
                    var image = new BitmapImage(new Uri(_photoPath, UriKind.RelativeOrAbsolute));
                    return image;
                }
                else
                {
                    // source: https://stackoverflow.com/questions/3573863/create-an-empty-bitmapsource-in-c-sharp
                    var image = BitmapSource.Create(
                        2,
                        2,
                        96,
                        96,
                        PixelFormats.Indexed1,
                        new BitmapPalette(new List<Color> { Colors.Transparent }),
                        new byte[] { 0, 0, 0, 0 },
                        1);
                    return image;
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

        public static DoctorViewModel FromModel(Doctor model)
        {
            var doctorViewModel = Mapper.Map<Doctor, DoctorViewModel>(model);
            return doctorViewModel;
        }

        public Doctor ToModel()
        {
            var model = Mapper.Map<DoctorViewModel, Doctor>(this);
            return model;
        }

    }
}
