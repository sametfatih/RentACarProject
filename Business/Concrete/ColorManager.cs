using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Utilities.Results;
using Business.Constants;

namespace Business.Concrete
{
    public class ColorManager : IColorService
    {
        IColorDal _colorDal;

        public ColorManager(IColorDal colorDal)
        {
            _colorDal = colorDal;
        }

    
        public IDataResult<List<Color>> GetAll()
        {
            return new SuccessDataResult<List<Color>>( _colorDal.GetAll(),Messages.ColorsListed);
        }

        public IDataResult<Color> GetByColorId(int id)
        {
            return new SuccessDataResult<Color>( _colorDal.Get(c => c.Id == id),Messages.ColorListedById);
        }
    }
}
