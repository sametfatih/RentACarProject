using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ICarService
    {
        IDataResult<List<Car>> GetAll();
        IDataResult<List<Car>> GetAllByBrandId(int brandId);
        IDataResult<List<Car>> GetAllByColorId(int colorId);
        IDataResult<Car> GetByCarId(int carId);

        IResult AddCar(Car car);
        IResult UpdateCar(Car car);
        IResult DeleteCar(Car car);

        IDataResult<List<CarDetailDto>> GetCarDetails();
    }
}
