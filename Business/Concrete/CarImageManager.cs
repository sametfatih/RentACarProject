using Business.Abstract;
using Business.Constants;
using Core.Utilities.Business;
using Core.Utilities.Helpers.FileHelpers;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class CarImageManager : ICarImageService
    {
        ICarImageDal _carImageDal;
        IFileHelperService _fileHelperService;
        public CarImageManager(ICarImageDal carImageDal,IFileHelperService fileHelperService)
        {
            _carImageDal = carImageDal;
            _fileHelperService = fileHelperService;
        }

        public IResult Add(List<IFormFile> formFiles,CarImage carImage)
        {
            IResult result = BusinessRules.Run(CheckImageLimit(carImage.CarId));

            if (result != null)
            {
                return result;
            }

            carImage.ImagePath = _fileHelperService.Upload(formFiles).Message;
            carImage.ImageDate = DateTime.Now;
           _carImageDal.Add(carImage);

           return new SuccessResult(Messages.CarImageAdded);
        }

        public IResult Delete(CarImage carImage)
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<CarImage>> GetAll()
        {
            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll()); ;
        }

        public IDataResult<List<CarImage>> GetAllImagesByCarId(int carId)
        {
            var result = _carImageDal.GetAll(c => c.CarId == carId).Any();
            if (!result)
            {
           
                List<CarImage> carImage = new List<CarImage>() { new CarImage { Id = 0, CarId = carId, ImageDate = null, ImagePath = "/images/default.jpg" } };
                return new SuccessDataResult<List<CarImage>>(carImage);
            }

            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll(c => c.CarId == carId), Messages.CarImagesListedByCarId); 
        }

        private IResult CheckImageLimit(int id)
        {
            var result = _carImageDal.GetAll(p=>p.CarId==id);
            if (result.Count>5)
            {
                return new ErrorResult(Messages.ImageLimitExceded);
            }
            return new SuccessResult();
        }

    }
}
