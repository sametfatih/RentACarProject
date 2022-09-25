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
    public class EfModelDal : EfEntityRepositoryBase<Model, ReCapContext>, IModelDal
    {
        public List<ModelDetailDto> GetModelDetails()
        {
            using (ReCapContext context = new ReCapContext())
            {
                var result = from b in context.Brands
                             join m in context.Models on b.Id equals m.BrandId
                             select new ModelDetailDto
                             {
                                 ModelId = m.Id,
                                 BrandName = b.BrandName,
                                 ModelName = m.ModelName
                             };
                return result.ToList();
            }
        }
    }
}
