using Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Entities.DTOs
{
    public class CarDetail:IDto
    {
        public string CarName { get; set; }
        public string BrandName { get; set; }
        public int ColorId { get; set; }
        public int BrandId { get; set; }
        public string ColorName { get; set; }
        public decimal DailyPrice { get; set; }
        public string Description { get; set; }
        [JsonPropertyName("carId")]  //buraya ne yazarsam json cevabı olarak o dönüyor. yani içeri id yazsam carId yerine id olarak döner.
        public int CarId { get; set; }
        public int ModelYear { get { return _modelYear.Year; } set { _modelYear = new DateTime(value, 1, 1); } }
        public override string ToString()
        {
            return $"{this.CarName}, {this.ColorName}, {this.BrandName}, {this.DailyPrice}";
        }
        private DateTime _modelYear;
        public string? ImagePath { get; set; }
    }
}
