using reppat.Business.Abstract;
using reppat.DataAccess.Abstract;
using reppat.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace reppat.Business.Concrete
{
    public class PersonalManager : IPersonalService
    {
        IPersonalDal _personalDal;

        public PersonalManager(IPersonalDal personalDal)
        {
            _personalDal = personalDal;
        }

        public Personal Add(Personal personal)
        {
            return _personalDal.Add(personal);
        }

        public Personal Get(int personalId)
        {
            return _personalDal.Get(x=>x.PersonalId == personalId);
        }

        public List<Personal> GetList()
        {
            return _personalDal.GetList();
        }

        public Personal Update(Personal personal)
        {
            return _personalDal.Update(personal);
        }
    }
}
