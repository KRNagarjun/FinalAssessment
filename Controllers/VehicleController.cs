using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FinalAssessment.Models;

namespace FinalAssessment.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VehicleController : Controller
    {
        [Route("postTruckdetails")]
        [HttpPost]
        public string PostVehicle([FromBody] GnmTruckDetails truckDetails)
        {
            try
            {
                using (CoreDbContext entities = new CoreDbContext())
                {
                    entities.GnmTruckDetails.Add(truckDetails);
                    entities.SaveChanges();
                    return "Vehicle Details Added Successfully!";
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
