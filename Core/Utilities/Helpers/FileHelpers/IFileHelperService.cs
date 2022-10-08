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
        public string Upload(List<IFormFile> file, string root);
  
    }
}
