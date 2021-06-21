using Microsoft.EntityFrameworkCore.Metadata;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using test_ren.Database;
using test_ren.Models;

namespace test_ren.Repositories
{
    public class TimeSlotRepository : TimeSlot
    {
        private ApplicationContext Context { get; set; }

        public TimeSlotRepository(ApplicationContext context)
        {
            Context = context;
        }

        public List<TimeSlot> GetAll()
        {
            return Context.Set<TimeSlot>().ToList();
        }
        public TimeSlot Get(int id)
        {
            return Context.Set<TimeSlot>().FirstOrDefault(m => m.Id == id);
        }
        public TimeSlot Create(TimeSlot model)
        {
            Context.Set<TimeSlot>().Add(model);
            Context.SaveChanges();
            return model;
        }
        public TimeSlot Update(TimeSlot model)
        {
            var toUpdate = Context.Set<TimeSlot>().Find(model);
            if (toUpdate != null)
            {
                toUpdate = model;
            }
            Context.Update(toUpdate);
            Context.SaveChanges();
            return toUpdate;
        }
        public void Delete(int id)
        {
            var toDelete = Context.Set<TimeSlot>().FirstOrDefault(m => m.Id == id);
            Context.Set<TimeSlot>().Remove(toDelete);
            Context.SaveChanges();
        }
    }
}
