using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EquipDisplay.Models
{
    public class Equipment
    {
        [Key]
        public int ID { get; set; }
        public List<SerialisedEquipment> SerialisedEquipment { get; set; }
        public List<EquipmentType> EquipmentType { get; set; }
    }
}