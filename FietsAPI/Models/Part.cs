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
       

        public ICollection<PartsRelation> DependantParts { get; set; }
        public ICollection<PartsRelation> DominantParts { get; set; }
        public ICollection<BikePart> BikeParts { get; set; }

        #endregion
    }
}
