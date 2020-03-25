using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FietsAPI.Models
{
    public class Part
    {

        #region properties

        public int Id { get; set; }
        public string Name { get; set; }
        public string Beschrijving { get; set; }
        public Functionality Functionality { get; set; }
        public ICollection<Part> AfhankelijkeParts { get; set; }

        #endregion
    }
}
