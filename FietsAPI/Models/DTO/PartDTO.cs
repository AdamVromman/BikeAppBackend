using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FietsAPI.Models.DTO
{
    public class PartDTO
    {

        public int Id { get; set; }
        public String Name { get; set; }
        public String Description { get; set; }
        public String Functionality { get; set; }
        public Boolean IsOptional { get; set; }
        public ICollection<String> DependantParts { get; set; }
        public ICollection<String> DominantParts { get; set; }

    }
}
