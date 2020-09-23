using BLL.DTO.Production;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Warehouse.Models
{
    public class ProductionList
    {
       
        public IEnumerable<ProductionDTO> Productions { get; set; }
    }
}
