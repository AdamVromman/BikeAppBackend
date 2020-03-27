using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FietsAPI.Models
{
    public interface IPartRepository
    {
        public IEnumerable<Part> GetAll();
        public Part GetById(int id);
        public IEnumerable<Part> GetByFunctionality(Functionality Functionality);
        public void AddPart(Part part);
        public void SaveChanges();
        
       

    }
}
