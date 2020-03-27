using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FietsAPI.Models.DTO
{
    public class registerDTO : LoginDTO
    {
        [Required]
        [StringLength(64)]
        public String FirstName { get; set; }
        [Required]
        [StringLength(64)]
        public String LastName { get; set; }
        [Required]
        [Compare("Password")]
        [RegularExpression(".{10,}$",
            ErrorMessage = "Password must be at least 10 characters and contain at least lower and upper cases.")]
        public String PasswordConfirmation { get; set; }

    }
}
