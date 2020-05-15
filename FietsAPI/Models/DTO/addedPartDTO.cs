using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FietsAPI.Models.DTO
{
    public class addedPartDTO
    {
        public int id { get; set; }
        public string name { get; set; }
        public string brand { get; set; }
        public decimal price { get; set; }
        public int partId { get; set; }
        public string email { get; set; }
        public string link { get; set; }

    }
}
