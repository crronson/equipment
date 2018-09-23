using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EquipDisplay.Models
{
    public class Display
    {
        [Required(ErrorMessage = "Meter Reading is required. Numbers only.")]
        public int MeterReading { get; set; }
        public string ExternalId { get; set; }
        [Required(ErrorMessage = "Description is required")]
        public string Description { get; set; }
        public int ID { get; set; }
    }
}