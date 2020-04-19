using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FietsAPI.Models
{
    public class BikePart
    {

        public Bike Bike { get; set; }
        public Part Part { get; set; }
        public int BikeId { get;set; }
        public int PartId { get; set; }


    }
}
