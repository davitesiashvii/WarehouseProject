using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BLL.DTO.Production
{
    public class CreateProductionDTO
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string ManufacturerCompany { get; set; }
        [Required]
        public string Image { get; set; }

        public IFormFile File { get; set; }
    }
}
