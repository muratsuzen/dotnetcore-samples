using reppat.Core.DataAccess.EntityFramework;
using reppat.DataAccess.Abstract;
using reppat.DataAccess.Concrete.EntityFramework.Contexts;
using reppat.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace reppat.DataAccess.Concrete.EntityFramework
{
    public class EfPersonalDal : EfBaseEntityRepository<Personal,ReppatContext>,IPersonalDal
    {
    }
}
