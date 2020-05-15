using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace FietsAPI.Models
{
    public class Image
    {

        public int Id { get; }
        public byte[] ImageData { get; set; }
        public AddedPart Part { get; set; }
        public int PartId { get; set; }
    }
}
