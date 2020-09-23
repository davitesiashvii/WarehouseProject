using BLL.DTO.Shope;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Warehouse.Models
{
    public class ShopeList
    {
        public IEnumerable<ShopeDTO> Shopes { get; set; }
    }
}
