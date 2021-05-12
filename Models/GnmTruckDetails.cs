using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FinalAssessment.Models
{
    [Table("GNM_TruckDetails")]
    public partial class GnmTruckDetails
    {
        [Key]
        [Column("TruckID")]
        public int TruckId { get; set; }
        public string TruckRegisterNumber { get; set; }
        public string TruckFitnessExpiry { get; set; }
        public string TruckModel { get; set; }
        public string TruckHaulingCapacity { get; set; }
    }
}
