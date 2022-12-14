using Entities.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Utilities.Results;

namespace Business.Abstract
{
    public interface IModelService
    {
        IDataResult<List<ModelDetailDto>> GetModelDetails();
    }
}
