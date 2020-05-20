using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FietsAPI.Models.DTO
{
    public class ImageDTO
    {
        
        public byte[] ImageData { get; set; }
        public int PartId { get; set; }
    }
}
