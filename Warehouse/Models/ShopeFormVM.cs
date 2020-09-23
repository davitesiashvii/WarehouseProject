using BLL.DTO.Shope;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Warehouse.Models
{
    public class ShopeFormVM
    {
        public CreateShopeComponents Components { get; set; }

        public ShopeFormDTO Shope { get; set; }
    }
}
