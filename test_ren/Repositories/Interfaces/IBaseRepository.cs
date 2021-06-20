using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using test_ren.Models.Base;

namespace test_ren.Repositories.Interfaces
{
    public interface IBaseRepository<TDbModel> where TDbModel : BaseModel
    {
        List<TDbModel> GetAll();
        TDbModel Get(int id);
        TDbModel Create(TDbModel model);
        TDbModel Update(TDbModel model);
        void Delete(int id);
    }
}
