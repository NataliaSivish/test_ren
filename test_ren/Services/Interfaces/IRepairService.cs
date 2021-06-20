using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using test_ren.Database;
using test_ren.Models;

namespace test_ren.Services.Interface
{
    public interface IRepairService
    {
        void CreateTimeSlot();
        void CreateSlots();
        List<Office> GetOffices();
        List<TimeSlot> GetTimeSlotsForDate(int officeId, DateTime _date);
        void Booking(int timeSlotId);
    }
}
