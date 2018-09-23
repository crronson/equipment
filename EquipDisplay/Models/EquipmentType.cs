using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EquipDisplay.Models
{
    public class EquipmentType
    {
        [Key]
        public string Id { get; set; }
        public int ExternalId { get; set; }
        public string Description { get; set; }
    }
}