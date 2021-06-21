using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestGetOffices()
        {
            TimeSlotService service = new TimeSlotService(new ApplicationCntext());
            var result = service.GetOffices();
            Assert.IsNotNull(result, "Не удалось получить список офисов");
        }

        [TestMethod]
        public void TestCreateSlots()
        {
            TimeSlotService service = new TimeSlotService(new ApplicationCntext());
            var listOffice = service.GetOffices();
            service.CreateSlots();
            var toList = service.GetOffices();
            Assert.AreNotEqual(listOffice, toList);
        }

        [TestMethod]
        public void TestGetTimeSlotsForDate()
        {
            TimeSlotService service = new TimeSlotService(new ApplicationCntext());
            var result = service.GetTimeSlotsForDate(1, DateTime.Now);
            Assert.IsNotNull(result, "Не удалось получить список слотов под дате и офису");
        }

        [TestMethod]
        public void TestBooking()
        {
            TimeSlotService service = new TimeSlotService(new ApplicationCntext());
            int slotID = 2;
            var slot = service.GetTimeSlot(slotID);
            var toSlot = service.Booking(slotID);
            Assert.AreNotEqual(slot, toSlot);
        }
    }
}
