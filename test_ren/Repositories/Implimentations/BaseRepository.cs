using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using test_ren.Database;
using test_ren.Models.Base;
using test_ren.Repositories.Interfaces;

namespace test_ren.Repositories.Implimentations
{
    public class BaseRepository<TDbModel> : IBaseRepository<TDbModel> where TDbModel: BaseModel
    {
        private ApplicationContext Context { get; set; }

        public BaseRepository(ApplicationContext context)
        {
            Context = context;
        }

        public List<TDbModel> GetAll() {
            return Context.Set<TDbModel>().ToList();
        }
        public TDbModel Get(int id) {
            return Context.Set<TDbModel>().FirstOrDefault(m => m.Id == id);
        }
        public TDbModel Create(TDbModel model) {
            Context.Set<TDbModel>().Add(model);
            Context.SaveChanges();
            return model;
        }
        public TDbModel Update(TDbModel model) {
            var toUpdate = Context.Set<TDbModel>().FirstOrDefault(m => m.Id == model.Id);
            if (toUpdate != null) {
                toUpdate = model;
            }
            Context.Update(toUpdate);
            Context.SaveChanges();
            return toUpdate;
        }
        public void Delete(int id) {
            var toDelete = Context.Set<TDbModel>().FirstOrDefault(m => m.Id == id);
            Context.Set<TDbModel>().Remove(toDelete);
            Context.SaveChanges();
        }
    }
}
