﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BLL.DTO.Shope
{
    public class ShopeDTO
    {
        public int Id { get; set; }

        
        public string Name { get; set; }

        
        public string Address { get; set; }

        
        public string Type { get; set; }

        public List<string> Productions { get; set; }
    }
}
