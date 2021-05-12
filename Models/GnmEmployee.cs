using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FinalAssessment.Models
{
    [Table("GNM_Employee")]
    public partial class GnmEmployee
    {
        [Key]
        [Column("EmpID")]
        public int EmpId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string LicenseNumber { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? LicenseExpiryDate { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? ModifiedDate { get; set; }
    }

    public class WeatherForecast
    {
        public DateTime Date { get; set; }
        public int temperature { get; set; }
        public string latitude { get; set; }
        public string longitude { get; set; }
        public int driverId { get; set; }
        public string truckrn { get; set; }
    }
}
