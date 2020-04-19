using FietsAPI.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FietsAPI.Models
{
    public interface IAddedPartRepository
    {

        public IEnumerable<AddedPart> GetAll();
        public IEnumerable<AddedPart> GetByBUserEmail(string email);
        public IEnumerable<AddedPart> GetByPartId(int id);
        public AddedPart GetById(int id);
        public void AddAddedPart(AddedPart part);
        public void SaveChanges();
        

       

    }
}
