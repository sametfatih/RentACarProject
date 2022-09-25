using Business.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Utilities.Results;
using Business.Constants;

namespace Business.Concrete
{
    public class ModelManager : IModelService
    {
        EfModelDal _modelDal;

        public ModelManager(EfModelDal modelDal)
        {
            this._modelDal = modelDal;
        }

        public IDataResult<List<ModelDetailDto>> GetModelDetails()
        {
            return new SuccessDataResult<List<ModelDetailDto>>( _modelDal.GetModelDetails(),Messages.ModelDetailsListed);
        }
    }
}
