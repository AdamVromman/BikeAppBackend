using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FietsAPI.Models
{
    public class Bike
    {
        #region properties

        public int Id { get; }
        public string Name { get; set; }
        public string Type { get; set; }
        public ICollection<Part> Parts { get; set; }

        #endregion
    }
}
