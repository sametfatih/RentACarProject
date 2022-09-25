using Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTO
{
    public class ModelDetailDto:IDto
    {
        public int ModelId { get; set; }
        public string BrandName { get; set; }
        public string ModelName { get; set; }
    }
}
