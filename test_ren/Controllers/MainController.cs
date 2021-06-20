using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using test_ren.Models;
using test_ren.Repositories.Interfaces;
using test_ren.Services.Interface;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace test_ren.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MainController : ControllerBase
    {
        private IBaseRepository<TimeSlot> TimeSlots { get; set; }
        private IBaseRepository<Office> Offices { get; set; }
        private IRestService RestService { get; set; }


        public MainController(IRestService repairService, IBaseRepository<TimeSlot> _timeSlots, IBaseRepository<Office> _offices)
        {
            RestService = repairService;
            Offices = _offices;
            TimeSlots = _timeSlots;
        }

        [HttpGet]
        public JsonResult GetTimeSlots()
        {
            return new JsonResult(TimeSlots.GetAll());
        }

        public JsonResult GetOffices()
        {
            return new JsonResult(Offices.GetAll());
        }

        [HttpPost]
        public JsonResult Post()
        {
           // RepairService.CreateTimeSlot();
            return new JsonResult("Work was successfully done");
        }

        [HttpPut]
        public JsonResult Put(TimeSlot _slot)
        {
            bool success = true;
            var slot = TimeSlots.Get(_slot.Id);
            try
            {
                if (slot != null)
                {
                    slot = TimeSlots.Update(_slot);
                }
                else
                {
                    success = false;
                }
            }
            catch (Exception)
            {
                success = false;
            }

            return success ? new JsonResult($"Update successful {slot.Id}") : new JsonResult("Update was not successful");
        }

        [HttpDelete]
        public JsonResult Delete(int id)
        {
            bool success = true;
            var slot = TimeSlots.Get(id);

            try
            {
                if (slot != null)
                {
                    TimeSlots.Delete(slot.Id);
                }
                else
                {
                    success = false;
                }
            }
            catch (Exception)
            {
                success = false;
            }

            return success ? new JsonResult("Delete successful") : new JsonResult("Delete was not successful");
        }
    }
}