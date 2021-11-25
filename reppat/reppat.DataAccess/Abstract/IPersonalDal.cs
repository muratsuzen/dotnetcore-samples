using reppat.Core.DataAccess;
using reppat.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace reppat.DataAccess.Abstract
{
    public interface IPersonalDal : IBaseEntityRepository<Personal>
    {
    }
}
