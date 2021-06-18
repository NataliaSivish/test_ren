using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using test_ren.Models.Base;

namespace test_ren.Models
{
    public class TimeSlot: BaseModel
    {
        public DateTime BeginTime { get; set; }
        public DateTime EngTime { get; set; }
        public DateTime Date { get; set; }
        public Boolean IsBusy { get; set; }
        public Guid OfficeId { get; set; }
    }
}
