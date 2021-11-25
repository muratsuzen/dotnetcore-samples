using reppat.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace reppat.Business.Abstract
{
    public interface IPersonalService
    {
        Personal Get(int personalId);
        List<Personal> GetList();
        Personal Add(Personal personal);
        Personal Update(Personal personal);        
    }
}
