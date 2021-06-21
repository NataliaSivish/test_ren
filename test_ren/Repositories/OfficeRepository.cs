using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using test_ren.Database;
using test_ren.Models;

namespace test_ren.Repositories
{
    public class OfficeRepository
    {
        private ApplicationContext Context { get; set; }

        public OfficeRepository(ApplicationContext context)
        {
            Context = context;
        }

        public List<Office> GetAll()
        {
            return Context.Set <Office> ().ToList();
        }

        public Office Get(Office model)
        {
            return Context.Set<Office>().Find(model);
        }

        public Office Get(int id)
        {
            return Context.Set<Office>().FirstOrDefault(m => m.Id == id);
        }

        public Office Update(Office model)
        {
            var toUpdate = Context.Set<Office>().Find(model);
            if (toUpdate != null)
            {
                toUpdate = model;
            }
            Context.Update(toUpdate);
            Context.SaveChanges();
            return toUpdate;
        }

    }
}
