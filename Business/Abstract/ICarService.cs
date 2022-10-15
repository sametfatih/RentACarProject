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
        

        IResult AddCar(Car car);
        IResult UpdateCar(Car car);
        IResult DeleteCar(Car car);

IDataResult<CarDetailDto> GetDetailsByCarId(int carId);
        IDataResult<List<CarDetailDto>> GetAllCarDetails();     
        IDataResult<List<CarDetailDto>> GetAllDetailsByBrandId(int brandId);
        IDataResult<List<CarDetailDto>> GetAllDetailsByColorId(int colorId);
    }
}
