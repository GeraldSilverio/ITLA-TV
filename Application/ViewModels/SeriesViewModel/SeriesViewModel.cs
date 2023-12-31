﻿


using System.ComponentModel.DataAnnotations;
using Database.Models;

namespace Application.ViewModels.SeriesViewModel
{
    public class SeriesViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string ImagenUrl { get; set; } = null!;
        public string VideoUrl { get; set; } = null!;
        public int IdProduction { get; set; }
        public int IdGender { get; set; }
        public int IdGenderSecundary { get; set; }
        public string ProductionName { get; set; } = null!;
        public string PrimaryGender { get; set; } = null!;
        public string SecundaryGender { get; set; } = null!;


    }
}
