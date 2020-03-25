using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FietsAPI.Models
{
    public class Part
    {

        #region properties
        [Required]
        public int Id { get; }
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
        public Functionality Functionality { get; set; }
        public bool IsOptional { get; set; }
        [Required]
        public ICollection<Part> DependantParts { get; set; }

        #endregion
    }
}
