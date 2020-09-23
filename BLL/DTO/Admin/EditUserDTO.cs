﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BLL.DTO.Admin
{
    public class EditUserDTO
    {
        public string Id { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        public List<string> Roles { get; set; }

        public List<string> UserRoles { get; set; }
    }
}
