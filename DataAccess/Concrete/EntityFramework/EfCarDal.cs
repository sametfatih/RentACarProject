using Core.DataAccess.EntityFramework;
using Core.Entities;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTO;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.Entity_Framework
{
    public class EfCarDal : EfEntityRepositoryBase<Car, ReCapContext>, ICarDal
    {
        public List<CarDetailDto> GetAllCarDetails(Expression<Func<CarDetailDto, bool>> filter = null)
        {
            using (ReCapContext context = new ReCapContext())
            {
                var result = from c in context.Cars
                             join b in context.Brands on c.BrandId equals b.Id
                             join co in context.Colors on c.ColorId equals co.Id
                             join m in context.Models on c.ModelId equals m.Id
                             select new CarDetailDto
                             {
                                 CarId = c.Id,
                                 BrandId = c.BrandId,
                                 ModelId = c.ModelId,
                                 ColorId = c.ColorId,
                                 Brand = b.BrandName,
                                 Model = m.ModelName,
                                 Color = co.ColorName,
                                 ModelYear = c.ModelYear,
                                 DailyPrice = c.DailyPrice,
                                 Description = c.Description
                             };
                return filter == null ? result.ToList():result.Where(filter).ToList();
            }
        }

        public CarDetailDto GetCarDetails(Expression<Func<CarDetailDto, bool>> filter = null)
        {
            using (ReCapContext context = new ReCapContext())
            {
                var result = from c in context.Cars
                             join b in context.Brands on c.BrandId equals b.Id
                             join co in context.Colors on c.ColorId equals co.Id
                             join m in context.Models on c.ModelId equals m.Id
                             select new CarDetailDto
                             {
                                 CarId = c.Id,
                                 BrandId = c.BrandId,
                                 ModelId = c.ModelId,
                                 ColorId = c.ColorId,
                                 Brand = b.BrandName,
                                 Model = m.ModelName,
                                 Color = co.ColorName,
                                 ModelYear = c.ModelYear,
                                 DailyPrice = c.DailyPrice,
                                 Description = c.Description
                             };
                return filter == null ? result.SingleOrDefault() : result.Where(filter).SingleOrDefault();
            }
        }
    }
}
