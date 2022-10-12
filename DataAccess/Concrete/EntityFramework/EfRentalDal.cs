using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Concrete.Entity_Framework;
using Entities.Concrete;
using Entities.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfRentalDal : EfEntityRepositoryBase<Rental, ReCapContext>, IRentalDal
    {
        public List<RentalDetailDTO> GetRentalDetails()
        {
            using (ReCapContext context=new ReCapContext())
            {
                var result = from r in context.Rentals
                             join c in context.Cars on r.CarId equals c.Id
                             join b in context.Brands on c.BrandId equals b.Id
                             join m in context.Models on c.ModelId equals m.Id
                             join co in context.Colors on c.ColorId equals co.Id
                             join c2 in context.Customers on r.CustomerId equals c2.Id
                             join u in context.Users on c2.UserId equals u.Id
                             select new RentalDetailDTO
                             {
                                 RentalId = r.Id,
                                 BrandName = b.BrandName,
                                 ModelName = m.ModelName,
                                 ModelYear = c.ModelYear,
                                 CustomerName = u.FirstName + " " + u.LastName,
                                 DailyPrice = c.DailyPrice,
                                 RentDate = r.RentDate,
                                 ReturnDate = r.ReturnDate
                             };
                return result.ToList();
                      
            }
        }
    }
}
