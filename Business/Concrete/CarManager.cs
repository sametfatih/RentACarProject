using Business.Abstract;
using Business.BusinessAspect.Autofac;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Performance;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Validation;
using Core.Entities;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTO;
using FluentValidation;
using FluentValidation.TestHelper;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        ICarDal _carDal;
        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }

        [SecuredOperation("car.add,admin")]
        [ValidationAspect(typeof(CarValidator))]
        [CacheRemoveAspect("ICarService.Get")]
        public IResult AddCar(Car car)
        {
            
            _carDal.Add(car);
            return new SuccessResult(Messages.CarAdded);
         
        }

        public IResult DeleteCar(Car car)
        {
            _carDal.Delete(car);
            return new SuccessResult(Messages.CarDeleted);
        }
        [CacheAspect(10)]
        [PerformanceAspect(5)]
        public IDataResult<List<Car>> GetAll()
        {
            return new SuccessDataResult<List<Car>>( _carDal.GetAll(),Messages.CarsListed);
        }

        public IDataResult<List<CarDetailDto>> GetAllDetailsByBrandId(int brandId)
        {
            return new SuccessDataResult<List<CarDetailDto>> (_carDal.GetAllCarDetails(c => c.BrandId == brandId),Messages.CarsListedByBrandId);
        }

        public IDataResult<List<CarDetailDto>> GetAllDetailsByColorId(int colorId)
        {
            return new SuccessDataResult<List<CarDetailDto>>( _carDal.GetAllCarDetails(c => c.ColorId == colorId), Messages.CarsListedByColorId);
        }

        public IDataResult<CarDetailDto> GetDetailsByCarId(int carId)
        {
            return new SuccessDataResult<CarDetailDto>( _carDal.GetCarDetails(c => c.CarId == carId),Messages.CarListedById);
        }

        public IDataResult<List<CarDetailDto>> GetAllCarDetails()
        {
           return new SuccessDataResult<List<CarDetailDto>>( _carDal.GetAllCarDetails(),Messages.CarDetailsListed);
        }

        public IResult UpdateCar(Car car)
        {
            _carDal.Update(car);
            return new SuccessResult(Messages.CarUpdated);
        }
    }
}
