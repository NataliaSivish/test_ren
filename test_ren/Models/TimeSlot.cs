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
        public DateTime EndTime { get; set; }
        public int OfficeId { get; set; }
        public int IsBusy { get; set; }

    }
}
