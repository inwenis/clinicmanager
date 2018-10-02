﻿using System;

namespace ClinicManager.Models
{
    public class Patient
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string Email { get; set; }
        public DateTimeOffset BirthDate { get; set; }
        public string InsuranceNumber { get; set; }
        public string PhoneNumber { get; set; }
        public string Photo { get; set; }
        public Doctor AssignedDoctor { get; set; }
    }
}