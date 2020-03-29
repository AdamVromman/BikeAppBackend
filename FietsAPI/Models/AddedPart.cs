using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FietsAPI.Models
{
    public class AddedPart
    {

        public int Id { get; }
        public String Name { get; set; }
        public String Brand { get; set; }
        public Part Part { get; set; }
        public Decimal Price { get; set; }
        public BUser BUser { get; set; }

    }
}
