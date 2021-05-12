using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FinalAssessment.Models;
using Microsoft.Extensions.Logging;

namespace FinalAssessment.Controllers
{
    [ApiController]
    public class EmployeeController : Controller
    {
        private static readonly string[] Summaries = new[]
              {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<EmployeeController> _logger;

        public EmployeeController(ILogger<EmployeeController> logger)
        {
            _logger = logger;
        }

        [Route("api/acme/stat/getdata")]
        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            try
            {
                var rng = new Random();
                return Enumerable.Range(1, 1).Select(index => new WeatherForecast
                {
                    Date = DateTime.Now.AddDays(index),
                    temperature = rng.Next(-20, 55),
                    latitude = Summaries[rng.Next(Summaries.Length)],
                    longitude = Summaries[rng.Next(Summaries.Length)],
                    driverId = 1,
                    truckrn = "KA06HJ8907"
                })
                .ToArray();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //FETCH
        [Route("api/acme/stat/getdata/{id}")]
        [HttpGet]
        public GnmEmployee Get(int id = 0)
        {
            try
            {
                using (CoreDbContext entities = new CoreDbContext())
                {
                    return entities.GnmEmployee.FirstOrDefault(e => e.EmpId == id);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //INSERT
        [Route("api/[controller]/postDriver")]
        [HttpPost]
        public string Post([FromBody] GnmEmployee EmployeeDetail)
        {
            try
            {
                //  WebapiContext context = new WebapiContext();
                using (CoreDbContext entities = new CoreDbContext())
                {
                    entities.GnmEmployee.Add(EmployeeDetail);
                    entities.SaveChanges();
                    return "Employee Details Added Successfully!";
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //UPDATE
        [Route("api/[controller]/update/{id}")]
        [HttpPut]
        public string Put([FromBody] GnmEmployee EmployeeDetail, int id = 0)
        {
            try
            {
                CoreDbContext context = new CoreDbContext();

                var entity = context.GnmEmployee.FirstOrDefault(e => e.EmpId == id);
                if (entity != null)
                {
                    entity.FirstName = EmployeeDetail.FirstName;
                    entity.LastName = EmployeeDetail.LastName;
                    entity.LicenseNumber = EmployeeDetail.LicenseNumber;
                    entity.LicenseExpiryDate = EmployeeDetail.LicenseExpiryDate;
                    entity.ModifiedDate = EmployeeDetail.ModifiedDate;
                    context.Update(entity);
                    context.SaveChanges();
                    return "Employee Details Updated Successfully!";
                }
                else
                {
                    return "No Records Found";
                }
            }
            catch (Exception ex)
            {
                return "error";
            }
        }


        //DELETE
        [HttpDelete]
        [Route("api/[controller]/delete/{id}")]
        public string Delete(int id)
        {
            try
            {
                CoreDbContext context = new CoreDbContext();
                context.GnmEmployee.Remove(context.GnmEmployee.FirstOrDefault(e => e.EmpId == id));
                context.SaveChanges();
                return "Employee with Id " + id.ToString() + " is deleted!";
            }
            catch (Exception ex)
            {
                return "Unable Delete";
            }

        }
    }
}
