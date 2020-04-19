using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FietsAPI.Models.DTO
{
    public class BikeDTO
    {
        public int Id { get; set; }
        public String Name { get; set; }
        public String Type { get; set; }
        public ICollection<PartDTO> Parts { get; set; }

    }
}
