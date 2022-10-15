using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal //: ICarDal
    {

        List<Car> _cars=new List<Car> {
            new Car { Id=1,BrandId=2,ColorId=3,ModelYear=new DateTime(2012),DailyPrice=140,Description="1. Araç"},
            new Car { Id=2,BrandId=1,ColorId=2,ModelYear=new DateTime(2016),DailyPrice=180,Description="2. Araç"},
            new Car { Id=3,BrandId=2,ColorId=1,ModelYear=new DateTime(2014),DailyPrice=200,Description="3. Araç"},
            new Car { Id=4,BrandId=4,ColorId=4,ModelYear=new DateTime(2016),DailyPrice=130,Description="4. Araç"},
            new Car { Id=5,BrandId=3,ColorId=2,ModelYear=new DateTime(2017),DailyPrice=100,Description="5. Araç"},
        };

        public void Add(Car car)
        {
            _cars.Add(car);   
        }

        public void Delete(Car car)
        {
            Car carToDelete = _cars.FirstOrDefault(c => c.Id == car.Id);
            _cars.Remove(carToDelete);
        }

        public Car Get(Expression<Func<Car, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetAll()
        {
            return _cars;
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public Car GetById(int id)
        {
            return _cars.FirstOrDefault(c => c.Id == id);
        }

        public List<CarDetailDto> GetCarDetails()
        {
            throw new NotImplementedException();
        }

        public List<CarDetailDto> GetAllCarDetails(Expression<Func<CarDetailDto, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public void Update(Car car)
        {
            Car carToUpdate = _cars.FirstOrDefault(c => c.Id == car.Id);
            carToUpdate.ColorId = car.ColorId;
            carToUpdate.ModelYear = car.ModelYear;
            carToUpdate.DailyPrice = car.DailyPrice;
            carToUpdate.Description = car.Description;
        }
    }
}
