using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Car:IEntity
    {
        [JsonPropertyName("carId")]  //buraya ne yazarsam json cevabı olarak o dönüyor. yani içeri id yazsam carId yerine id olarak döner.
        public int Id { get; set; }
        public int BrandId { get; set; }
        public int ColorId { get; set; }
        public int ModelYear { get { return _modelYear.Year; } set { _modelYear = new DateTime(value, 1, 1); } }
        [Range(0.0, Double.MaxValue, ErrorMessage = "The field {0} must be greater than {1}.")]
        public decimal DailyPrice { get; set; }
        public string Description { get; set; }
        private DateTime _modelYear;
    }
}
