using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EquipDisplay.Dtos
{
    public class DisplayDto
    {
        
        public int MeterReading { get; set; }
        public string ExternalId { get; set; }
        
        public string Description { get; set; }
        public int ID { get; set; }
    }
}