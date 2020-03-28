using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FietsAPI.Models
{
    public class PartsRelation
    {

        public Part DominantPart { get; set; }
        public Part DependantPart { get; set; }

        public int DomId { get; set; }
        public int DepId { get; set; }

        public PartsRelation()
        {
           
        }

    }
}
