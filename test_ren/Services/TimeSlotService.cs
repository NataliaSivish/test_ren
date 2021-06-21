using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using test_ren.Models;
using test_ren.Repositories;

namespace test_ren.Services
{
    public class TimeSlotService
    {
        private TimeSlotRepository slotRepository;
        private OfficeRepository officeRepository;

        public void CreateSlots()  // Единождое создание слотов, на 10 для всех офисов
        {
            for (int i = 0; i < 10; i++)
            {
                foreach (Office office in GetOffices())
                {
                    CreateTimeSlotForOffice(office, i + 1);
                }
            }

        }

        public void CreateTimeSlot() //Создание слотов для каждого офиса, когда проходит день
        {
            foreach (Office office in GetOffices())
            {
                CreateTimeSlotForOffice(office, 10);
            }
        }

        public List<Office> GetOffices()
        {
            return officeRepository.GetAll().ToList();
        }

        public List<TimeSlot> GetTimeSlotsForDate(int officeId, DateTime _date)
        {
            List<TimeSlot> result = new List<TimeSlot>();
            foreach (TimeSlot slot in slotRepository.GetAll())
            {
                if (slot.Id == officeId)
                {
                    var dateSlot = slot.BeginTime;
                    if (dateSlot.Day == _date.Day && dateSlot.Year == _date.Year && dateSlot.Month == _date.Month)
                    {
                        result.Add(slot);
                    }
                }
            }
            return result;
        }

        public void Booking(int timeSlotId)
        {
            var slot = slotRepository.Get(timeSlotId);
            slot.IsBusy = 1;
            slotRepository.Update(slot);
        }

        private void CreateTimeSlotForOffice(Office _office, int addDays)
        {
            var timeSlotId = slotRepository.GetAll().Count + 1;
            var date = DateTime.Now.AddDays(addDays);
            var countTimeSlot = (_office.EndTime - _office.BeginTime).Minutes / 30;
            var _beginTime = new DateTime(date.Year, date.Month, date.Day,
                _office.BeginTime.Hour, _office.BeginTime.Minute, _office.BeginTime.Second);
            var _endTime = _beginTime.AddMinutes(30);
            for (int i = 0; i < countTimeSlot; i++)
            {
                slotRepository.Create(new TimeSlot
                {
                    Id = timeSlotId,
                    BeginTime = _beginTime,
                    EndTime = _endTime,
                    OfficeId = _office.Id,
                    IsBusy = 0
                });
                _beginTime = _endTime;
                _endTime = _beginTime.AddMinutes(30);
            }
        }
    }
}
