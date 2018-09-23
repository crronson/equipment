using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EquipDisplay.Models
{
    public class SerialisedEquipment
    {
        [Key]
        public string Id { get; set; }
        public string ExternalId { get; set; }
        public string EquipmentTypeId { get; set; }
        public int MeterReading { get; set; }
    }
}