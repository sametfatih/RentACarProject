using Core.DataAccess;
using Entities.Concrete;
using Entities.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface ICarDal:IEntityRepository<Car>
    {
        List<CarDetailDto> GetAllCarDetails(Expression<Func<CarDetailDto, bool>> filter = null);
            CarDetailDto GetCarDetails(Expression<Func<CarDetailDto, bool>> filter = null);
    }
}
