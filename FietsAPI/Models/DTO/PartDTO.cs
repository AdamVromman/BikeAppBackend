using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FietsAPI.Models.DTO
{
    public class PartDTO
    {

        public String Naam { get; set; }
        public String Beschrijving { get; set; }
        public Functionality Functionaliteit { get; set; }
        public Boolean IsOptional { get; set; }
        public ICollection<String> DependantParts { get; set; }
        public ICollection<String> DominantParts { get; set; }

    }
}
