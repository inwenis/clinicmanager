﻿using System.Windows;
using AutoMapper;
using ClinicManager.Models;
using ClinicManager.ViewModels;

namespace ClinicManager
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            InitializeMapper();
        }

        public static void InitializeMapper()
        {
            Mapper.Initialize(cfg =>
                {
                    cfg.CreateMap<Patient, PatientViewModel>()
                        .ForPath(dest => dest.Model, opt => opt.MapFrom(src => src))
                        .ReverseMap();
                    cfg.CreateMap<Doctor, DoctorViewModel>()
                        .ForPath(dest => dest.Model, opt => opt.MapFrom(src => src))
                        .ForPath(dest => dest.PhotoPath, opt => opt.MapFrom(src => src.Photo))
                        .ReverseMap();
                }
            );
        }
    }
}
