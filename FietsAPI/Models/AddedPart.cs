using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FietsAPI.Models
{
    public class AddedPart
    {

        public int Id { get; }
        public string Name { get; set; }
        public string Brand { get; set; }
        public Part Part { get; set; }
        public decimal Price { get; set; }
        public BUser BUser { get; set; }
        public string Link { get; set; }

    }
}
