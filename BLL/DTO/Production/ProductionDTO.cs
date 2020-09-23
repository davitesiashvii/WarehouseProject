using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.DTO.Production
{
    public class ProductionDTO
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string ManufacturerCompany { get; set; }

        public string Image { get; set; }

        public bool isDeleted { get; set; }

    }
}
