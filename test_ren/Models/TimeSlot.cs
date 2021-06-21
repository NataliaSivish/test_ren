using Microsoft.EntityFrameworkCore.Metadata;
using System;


namespace test_ren.Models
{
    public class TimeSlot
    {
        public int Id { get; set; }
        public DateTime BeginTime { get; set; }
        public DateTime EndTime { get; set; }
        public int OfficeId { get; set; }
        public int IsBusy { get; set; }

    }
}
