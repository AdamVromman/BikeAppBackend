using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FietsAPI.Models.DTO
{
    public class LoginDTO
    {
        [Required]
        public String Email { get; set; }
        [Required]
        public String Password { get; set; }

    }
}
