﻿using Core.Utilities.Results;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Helpers.FileHelpers
{
    public interface IFileHelperService
    {
        public IResult Upload(List<IFormFile> files);
  
    }
}
